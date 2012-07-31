//
//  ServiceProxy.cs
//  TangoCard_DotNet_SDK
//  
//  © 2012 Tango Card, Inc
//  All rights reserved.
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions: 
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software. 
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using System.Security;

using Newtonsoft.Json;

using TangoCard.Sdk;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Response;
using TangoCard.Sdk.Response.Failure;
using System.Security.Cryptography.X509Certificates;

namespace TangoCard.Sdk.Service
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Tango service proxy. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    internal class ServiceProxy
    {
        private string _base_url;
        private string _controller;
        private string _action;
        private string _path;

        private Request.BaseRequest _requestObject;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="TangoCardSdkException">    Thrown when a tango card sdk error condition
        ///                                             occurs. </exception>
        /// <exception cref="Exception">                Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="requestObject">    The request object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ServiceProxy(Request.BaseRequest requestObject)
        {
            if (null == requestObject)
            {
                throw new ArgumentNullException(paramName: "requestObject");
            }
            try
            {
                SdkConfig appConfig = SdkConfig.Instance;

                string version = appConfig["tc_sdk_version"];

                this._base_url = null;
                switch (requestObject.TangoCardServiceApi)
                {
                    case TangoCardServiceApiEnum.INTEGRATION:
                        this._base_url = appConfig["tc_sdk_environment_integration_url"];
                        break;

                    case TangoCardServiceApiEnum.PRODUCTION:
                        this._base_url = appConfig["tc_sdk_environment_production_url"];
                        break;

                    default:
                        throw new TangoCardSdkException(message: "Unexpected Tango Card Service API request: " + requestObject.TangoCardServiceApi.ToString());
                }

                if (null == this._base_url)
                {
                    throw new TangoCardSdkException(message: "Tango Card Service API URL was not assigned.");
                }

                this._controller = appConfig["tc_sdk_controller"];

                this._requestObject = requestObject;
                this._action = requestObject.RequestAction;
                this._path = String.Format("{0}/{1}/{2}", this._base_url, this._controller, this._action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Writes the json post data to the request. </summary>
        ///
        /// <param name="webRequest">   [in,out]. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool mapRequest(ref HttpWebRequest webRequest)
        {
            if (null == webRequest)
            {
                throw new ArgumentNullException(paramName: "webRequest");
            }
            if (null == this._requestObject)
            {
                throw new NullReferenceException(message: "Member variable '_requestObject' is null.");
            }
            
            bool isSuccess = false;
            try
            {
                StringBuilder postDataStringBuilder = new StringBuilder();

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                string requestJsonSerialized = JsonConvert.SerializeObject(this._requestObject);
                if (!String.IsNullOrEmpty(requestJsonSerialized))
                {
                    byte[] data = UTF8Encoding.UTF8.GetBytes(requestJsonSerialized);
                    webRequest.ContentLength = data.Length;
                    using (Stream requestDataStream = webRequest.GetRequestStream())
                    {
                        requestDataStream.Write(data, 0, data.Length);
                        requestDataStream.Close();
                    }

                    isSuccess = true;
                }
            }
            catch (TangoCardSdkException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new TangoCardSdkException("Failed to map request: " + ex.Message, ex);
            }

            return isSuccess;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes the actual call to Service. </summary>
        ///
        /// <exception cref="WebException">         Thrown when a web error condition occurs. </exception>
        /// <exception cref="TangoCardSdkException"> Thrown when an application error condition occurs. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool postRequest(ref string responseJsonEncoded)
        {
            if (String.IsNullOrEmpty(this._path))
            {
                throw new NullReferenceException(message: "_path is not set.");
            }

            bool isSuccess = false;
            responseJsonEncoded = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(this._path);

                if (this.mapRequest(ref webRequest))
                {
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        responseJsonEncoded = readStream.ReadToEnd();                        
                    }

                    isSuccess = true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                {
                    throw;
                }

                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        responseJsonEncoded = streamReader.ReadToEnd();
                    }
                }
            }
            catch (TangoCardSdkException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new TangoCardSdkException("Failed to post request: " + ex.Message, ex);
            }

            return isSuccess;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Performs and request and returns the appropiate strongly-yyped Object. </summary>
        ///
        /// <typeparam name="T">    . </typeparam>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ExecuteRequest<T>(out T response) where T : BaseResponse
        {
            bool isSuccess = false;
            response = default(T);
            string responseJsonEncoded = null;
            try
            {
                if (this.postRequest(ref responseJsonEncoded))
                {
                    /*
                     * Json Deserealizer cannot convert to valid DateTime, replacing in case 
                     * this value exists replace.
                     */
                    responseJsonEncoded = responseJsonEncoded.Replace("0000-00-00 00:00:00", "0001-01-01 00:00:00");

                    Newtonsoft.Json.JsonSerializerSettings jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    jsonSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    jsonSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
                    jsonSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

                    TangoCardServiceException.ThrowOnError(responseJsonEncoded, jsonSettings);

                    var responseService = JsonConvert.DeserializeObject<ServiceResponse<T>>(responseJsonEncoded, jsonSettings);

                    response = responseService.Response;
                    isSuccess = true;
                }
            }
            catch (WebException ex)
            {
                WebFailureResponse responseServiceFailure = new WebFailureResponse
                {
                    Message = String.Format("{0}: {1}", ex.Status, ex.Message)
                };
                throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: responseServiceFailure, message: ex.Message);
            }
            catch (TangoCardServiceException ex)
            {
                throw ex;
            }
            catch (TangoCardSdkException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new TangoCardSdkException("Failed to process request: " + ex.Message, ex);
            }
            return isSuccess;
        }
    }
}