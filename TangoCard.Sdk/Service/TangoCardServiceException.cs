//
//  TangoCardServiceException.cs
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
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TangoCard.Sdk.Response;
using TangoCard.Sdk.Response.Failure;
using TangoCard.Sdk.Response.Success;

namespace TangoCard.Sdk.Service
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Exception for signalling tango card service errors. </summary>
    ///
    /// <seealso cref="System.Exception"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    [Serializable]
    public class TangoCardServiceException : System.Exception
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the response. </summary>
        ///
        /// <value> The type of the response. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ServiceResponseEnum ResponseType
        {
            get;
            private set;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the response belongs to. </summary>
        ///
        /// <value> The response category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FailureResponse Response
        {
            get;
            private set;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a message that describes the current exception. </summary>
        ///
        /// <seealso cref="System.Exception.Message"/>
        ///
        /// ### <returns>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string Message
        {
            get
            {
                return Response.Message.Trim();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="responseType">     The result. </param>
        /// <param name="responseCategory"> Category the response belongs to. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TangoCardServiceException(ServiceResponseEnum responseType, FailureResponse response)
            : this(responseType, response, string.Empty) 
        { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="responseType">     The result. </param>
        /// <param name="responseCategory"> Category the response belongs to. </param>
        /// <param name="message">          The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TangoCardServiceException(ServiceResponseEnum responseType, FailureResponse response, string message)
            : base(message)
        {
            this.ResponseType = responseType;
            this.Response = response;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Throw on error. </summary>
        ///
        ///  Throws a Service Exception if the given json sting is not of type "SUCCESS".
        ///
        /// <exception cref="TangoCardServiceException"> Thrown when a service error condition occurs. </exception>
        /// <exception cref="Exception">        Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="responseJsonEncoded">     The json body. </param>
        /// <param name="jsonSettings"> The json settings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ThrowOnError(string responseJsonEncoded, Newtonsoft.Json.JsonSerializerSettings jsonSettings)
        {
            ServiceResponse<FailureResponse> responseService 
                = JsonConvert.DeserializeObject<ServiceResponse<FailureResponse>>(responseJsonEncoded, jsonSettings);

            switch (responseService.ResponseType)
            {
                case ServiceResponseEnum.SUCCESS:
                    break;
                case ServiceResponseEnum.INS_FUNDS:
                    {
                        ServiceResponse<InsufficientFundsResponse> responseServiceFailure 
                            = JsonConvert.DeserializeObject<ServiceResponse<InsufficientFundsResponse>>(responseJsonEncoded, jsonSettings);
                        throw new TangoCardServiceException(responseServiceFailure.ResponseType, responseServiceFailure.Response);
                    }
                case ServiceResponseEnum.INV_CREDENTIAL:
                    {
                        ServiceResponse<InvalidCredentialsResponse> responseServiceFailure 
                            = JsonConvert.DeserializeObject<ServiceResponse<InvalidCredentialsResponse>>(responseJsonEncoded, jsonSettings);
                        throw new TangoCardServiceException(responseServiceFailure.ResponseType, responseServiceFailure.Response);
                    }
                case ServiceResponseEnum.SYS_ERROR:
                    {
                        ServiceResponse<SystemFailureResponse> responseServiceFailure 
                            = JsonConvert.DeserializeObject<ServiceResponse<SystemFailureResponse>>(responseJsonEncoded, jsonSettings);
                        throw new TangoCardServiceException(responseServiceFailure.ResponseType, responseServiceFailure.Response);
                    }
                case ServiceResponseEnum.INV_INPUT:
                    {
                        ServiceResponse<InvalidInputResponse> responseServiceFailure 
                            = JsonConvert.DeserializeObject<ServiceResponse<InvalidInputResponse>>(responseJsonEncoded, jsonSettings);
                        throw new TangoCardServiceException(responseServiceFailure.ResponseType, responseServiceFailure.Response);
                    }
                case ServiceResponseEnum.INS_INV:
                    {
                        ServiceResponse<InsufficientInventoryResponse> responseServiceFailure 
                            = JsonConvert.DeserializeObject<ServiceResponse<InsufficientInventoryResponse>>(responseJsonEncoded, jsonSettings);
                        throw new TangoCardServiceException(responseServiceFailure.ResponseType, responseServiceFailure.Response);
                    }
                default:
                    {
                        throw new Exception("Unknown error");
                    }
            }
        }
    }
}