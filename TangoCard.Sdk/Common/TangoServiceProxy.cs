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
using TangoCard.Sdk.Response;
using TangoCard.Sdk.Response.Failure;
using System.Security.Cryptography.X509Certificates;


namespace TangoCard.Sdk.Common
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Tango service proxy. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    internal class TangoServiceProxy
    {
        private string _base_url;
        private string _controller;
        private string _action;
        private string _path;

        private Request.BaseRequest _requestObject;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="requestObject">    The request object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TangoServiceProxy(Request.BaseRequest requestObject)
        {
            try
            {
                SdkConfig appConfig = SdkConfig.Instance;

                string version = appConfig["tc_sdk_version"]; 

                this._base_url = requestObject.IsProductionMode
                    ? appConfig["tc_sdk_environment_production_url"]
                    : appConfig["tc_sdk_environment_integration_url"];

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

        private void writeRequestPostData(ref HttpWebRequest webRequest)
        {
            StringBuilder postDataStringBuilder = new StringBuilder();

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";

            byte[] data = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this._requestObject));
            webRequest.ContentLength = data.Length;
            using (Stream requestDataStream = webRequest.GetRequestStream())
            {
                requestDataStream.Write(data, 0, data.Length);
                requestDataStream.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes the actual call to Service. </summary>
        ///
        /// <exception cref="WebException">         Thrown when a web error condition occurs. </exception>
        /// <exception cref="ApplicationException"> Thrown when an application error condition occurs. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string invoke()
        {
            string result = null;
            try
            {

                string certFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "thawte_Server_CA.pem");
                if ( !File.Exists(certFile) ) {
                    throw new SystemException( message: "Missing CA cert file" );
                }

                X509Certificate x509certificate = X509Certificate.CreateFromCertFile(certFile);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this._path);
                request.ClientCertificates.Add(x509certificate); 
                this.writeRequestPostData(ref request);
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream receiveStream = response.GetResponseStream())
                {
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    result = readStream.ReadToEnd();
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
                        result = streamReader.ReadToEnd();
                    }
                }
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed while trying to Invoke Service", ex);
            }

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Performs and request and returns the appropiate strongly-yyped Object. </summary>
        ///
        /// <typeparam name="T">    . </typeparam>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T Request<T>() where T : BaseResponse
        {
            string jsonBody = this.invoke();
            /*
             * Json Deserealizer cannot convert to valid DateTime, replacing in case 
             * this value exists replace.
             */
            jsonBody = jsonBody.Replace("0000-00-00 00:00:00", "0001-01-01 00:00:00");

            Newtonsoft.Json.JsonSerializerSettings jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            jsonSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            jsonSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

            ServiceException<FailureResponse>.ThrowOnError(jsonBody, jsonSettings);

            var result = JsonConvert.DeserializeObject<ServiceReponse<T>>(jsonBody, jsonSettings);

            return result.Response;
        }
    }
}