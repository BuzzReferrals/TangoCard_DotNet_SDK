//  
//  BaseRequest.cs
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
using System.Text;
using System.Configuration;

using Newtonsoft.Json;

using TangoCard.Sdk.Response;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Service;

namespace TangoCard.Sdk.Request
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Abstract request base.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class BaseRequest
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Constructor</summary>
        /// <param name="enumTangoCardServiceApi">The enum tango card service api.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BaseRequest(
            TangoCardServiceApiEnum enumTangoCardServiceApi,
            string username, 
            string password
        ) {
            // -----------------------------------------------------------------
            // validate inputs
            // -----------------------------------------------------------------

            // enumTangoCardServiceApi
            if (enumTangoCardServiceApi.Equals(TangoCardServiceApiEnum.UNDEFINED))
            {
                throw new ArgumentException(message: "Parameter 'enumTangoCardServiceApi' is not a defined service environment." );
            }

            // username
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(paramName: "username" );
            }

            // password
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(paramName: "password" );
            }

            this.TangoCardServiceApi = enumTangoCardServiceApi;
            this.Username = username;
            this.Password = password;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the username. </summary>
        ///
        /// <value> The username. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the password. </summary>
        ///
        /// <value> The password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the tango card service api. </summary>
        ///
        /// <value> The tango card service api. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonIgnore]
        public TangoCardServiceApiEnum TangoCardServiceApi { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the full pathname of the request file. </summary>
        ///
        /// <value> The full pathname of the request file. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonIgnore]
        public abstract string RequestAction
        {
            get;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the given out T. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="response"> [out] The response. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool Execute<T>(out T response) where T : BaseResponse
        {
            var proxy = new ServiceProxy(this);
            return proxy.ExecuteRequest<T>(out response);
        }
    }
}
