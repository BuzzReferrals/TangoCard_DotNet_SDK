//
//  ServiceProxy.cs
//  TangoCard_DotNet_SDK
//  
//  Copyright (c) 2013 Tango Card, Inc
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
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;

using TangoCard.Sdk;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Response;
using TangoCard.Sdk.Response.Failure;
using TangoCard.Sdk.Response.Success;
using Newtonsoft.Json.Linq;


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

                this._requestObject = requestObject;
                this._controller    = requestObject.RequestController;
                this._action        = requestObject.RequestAction;
                this._path          = String.Format("{0}/{1}/{2}", this._base_url, this._controller, this._action);
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

        private bool mapRequest(string requestSerialized, ref HttpWebRequest webRequest)
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
                webRequest.ContentType = "application/json; charset=utf-8";

                if (!String.IsNullOrEmpty(requestSerialized))
                {
                    string requestUrlEncoded = requestSerialized;
                    byte[] data = UTF8Encoding.UTF8.GetBytes(requestUrlEncoded);
                    webRequest.ContentLength = data.Length;
                    using (Stream requestDataStream = webRequest.GetRequestStream())
                    {
                        requestDataStream.Write(data, 0, data.Length);
                        requestDataStream.Close();
                    }

                    isSuccess = true;
                }
            }
            catch (WebException ex)
            {
                throw new TangoCardSdkException(message: ex.Message, innerException: ex);
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

        private bool postRequest(string requestSerialized, ref string bodyResponse)
        {
            if (String.IsNullOrEmpty(this._path))
            {
                throw new NullReferenceException(message: "_path is not set.");
            }

            bool isSuccess = false;
            bodyResponse = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(this._path);

                if (this.mapRequest(requestSerialized, ref webRequest))
                {
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        bodyResponse = readStream.ReadToEnd();                        
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
                        bodyResponse = streamReader.ReadToEnd();
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
        /// <summary>   Executes the request operation. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2013. </remarks>
        ///
        /// <exception cref="TangoCardServiceException">    Thrown when a tango card service error
        ///                                                 condition occurs. </exception>
        /// <exception cref="TangoCardSdkException">        Thrown when a tango card sdk error condition
        ///                                                 occurs. </exception>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="response"> [out] The response. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ExecuteRequest<T>(string requestSerialized, out T response) where T : SuccessResponse
        {
            bool isSuccess = false;
            response = default(T);
            string bodyResponse = null;
            try
            {
                if (!this.postRequest(requestSerialized, ref bodyResponse))
                {
                    throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: null, message: "Failed to post reqeust.");
                }

                if (bodyResponse.IsNullOrEmpty())
                {
                    throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: null, message: "Empty body response.");
                }

                JObject responseJson = JObject.Parse(bodyResponse);

                BaseResponse baseResponse = responseJson.Deserialize<BaseResponse>();

                if (baseResponse.ResponseType.IsNullOrEmpty() || !(baseResponse.ResponseType is String))
                {
                    throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: null, message: "Response type is not defined.");
                }

                if ((null == baseResponse.Response))
                {
                    throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: null, message: "Response is not defined.");
                }

                JObject responseObject = (JObject)responseJson["response"];

                ServiceResponseEnum enumResponseType = ServiceResponseEnum.UNDEFINED;

                if (!Enum.TryParse(baseResponse.ResponseType, true, out enumResponseType))
                {
                    throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: null, message: "Unknown response type returned.");
                }

                if (!ServiceResponseEnum.SUCCESS.Equals(enumResponseType))
                {
                    TangoCardServiceException.ThrowOnError(enumResponseType, responseObject);
                }

                response = responseObject.Deserialize<T>();

                isSuccess = true;
            }
            catch (WebException ex)
            {
                WebFailureResponse responseServiceFailure = new WebFailureResponse
                {
                    Message = String.Format("{0}: {1}", ex.Status, ex.Message)
                };
                throw new TangoCardServiceException(responseType: ServiceResponseEnum.WEB_ERROR, response: responseServiceFailure, message: ex.Message);
            }
            catch (InvalidDataContractException ex)
            {
                throw new TangoCardSdkException(ex.Message, ex);
            }
            catch (InvalidCastException ex)
            {
                throw new TangoCardSdkException(ex.Message, ex);
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