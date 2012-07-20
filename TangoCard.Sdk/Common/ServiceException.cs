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

namespace TangoCard.Sdk.Common
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Class. </summary>
    ///
    /// <seealso cref="System.Exception"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ServiceException<T> : Exception where T : FailureResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the response. </summary>
        ///
        /// <value> The type of the response. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ResponseType ResponseType
        {
            get;
            private set;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the result. </summary>
        ///
        /// <value> The result. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T Result
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
                return string.Format("{0} - {1}: {2}", ResponseType, Result, base.Message).Trim();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="result">   The result. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ServiceException(ServiceReponse<T> result) : this(result, string.Empty) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="result">   The result. </param>
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ServiceException(ServiceReponse<T> result, string message)
            : base(message)
        {
            ResponseType = result.ResponseType;
            Result = result.Response;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Throws a Service Exception if the given json sting is not of type "SUCCESS".
        /// </summary>
        ///
        /// <exception cref="ServiceException<InsufficientFundsResponse>">      Thrown when a service
        ///                                                                     exception&lt;
        ///                                                                     insufficient funds
        ///                                                                     response&gt; error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="ServiceException<InvalidCredentialsResponse>">     Thrown when a service
        ///                                                                     exception&lt; invalid
        ///                                                                     credentials response&gt;
        ///                                                                     error condition occurs. </exception>
        /// <exception cref="ServiceException<SystemFailureResponse>">            Thrown when a service
        ///                                                                     exception&lt; system
        ///                                                                     error response&gt; error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="ServiceException<InvalidInputResponse>">           Thrown when a service
        ///                                                                     exception&lt; invalid
        ///                                                                     input response&gt; error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="ServiceException<InsufficientInventoryResponse>">  Thrown when a service
        ///                                                                     exception&lt;
        ///                                                                     insufficient inventory
        ///                                                                     response&gt; error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="Exception">                                        Thrown when an exception
        ///                                                                     error condition occurs. </exception>
        ///
        /// <param name="jsonBody">     . </param>
        /// <param name="jsonSettings"> . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ThrowOnError(string jsonBody, Newtonsoft.Json.JsonSerializerSettings jsonSettings)
        {
            var x = JsonConvert.DeserializeObject<ServiceReponse<FailureResponse>>(jsonBody, jsonSettings);
            switch (x.ResponseType)
            {
                case ResponseType.SUCCESS:
                    break;
                case ResponseType.INS_FUNDS:
                    throw new ServiceException<InsufficientFundsResponse>(JsonConvert.DeserializeObject<ServiceReponse<InsufficientFundsResponse>>(jsonBody, jsonSettings));
                case ResponseType.INV_CREDENTIAL:
                    throw new ServiceException<InvalidCredentialsResponse>(JsonConvert.DeserializeObject<ServiceReponse<InvalidCredentialsResponse>>(jsonBody, jsonSettings));
                case ResponseType.SYS_ERROR:
                    throw new ServiceException<SystemFailureResponse>(JsonConvert.DeserializeObject<ServiceReponse<SystemFailureResponse>>(jsonBody, jsonSettings));
                case ResponseType.INV_INPUT:
                    throw new ServiceException<InvalidInputResponse>(JsonConvert.DeserializeObject<ServiceReponse<InvalidInputResponse>>(jsonBody, jsonSettings));
                case ResponseType.INS_INV:
                    throw new ServiceException<InsufficientInventoryResponse>(JsonConvert.DeserializeObject<ServiceReponse<InsufficientInventoryResponse>>(jsonBody, jsonSettings));
                default:
                    throw new Exception("Unknown error");
            }
        }
    }
}