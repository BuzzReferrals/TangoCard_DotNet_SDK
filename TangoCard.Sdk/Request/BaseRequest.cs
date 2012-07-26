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
    /// <summary>   Request base. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class BaseRequest
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="isProductionMode"> true if this object is production mode. </param>
        /// <param name="username">         The username. </param>
        /// <param name="password">         The password. </param>

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BaseRequest( 
            bool isProductionMode,
            string username, 
            string password
        ) {
            // -----------------------------------------------------------------
            // validate inputs
            // -----------------------------------------------------------------
            // username and password
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(paramName: "username" );
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(paramName: "password" );
            }

            this.IsProductionMode = isProductionMode;
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
        /// <summary>   Gets or sets a value indicating whether the production mode. </summary>
        ///
        /// <value> true if production mode, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonIgnore]
        public bool IsProductionMode { get; set; }

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
        /// <summary>   Gets the execute. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool Execute<T>(ref T response) where T : BaseResponse
        {
            var proxy = new ServiceProxy(this);
            return proxy.ExecuteRequest<T>(ref response);
        }
    }
}
