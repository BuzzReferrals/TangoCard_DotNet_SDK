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
        private ServiceEndpointEnum _endpoint = ServiceEndpointEnum.UNDEFINED;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="username"> The username. </param>
        /// <param name="password"> The password. </param>
        /// <param name="endpoint"> The endpoint. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BaseRequest( string username, string password, ServiceEndpointEnum endpoint )
        {
            this.Username = username;
            this.Password = password;
            this.Endpoint = endpoint;
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
        /// <summary>   Gets or sets the endpoint. </summary>
        ///
        /// <value> The endpoint. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ServiceEndpointEnum Endpoint
        {
            get
            {
                return this._endpoint;
            }
            set
            {
                this._endpoint = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the production mode. </summary>
        ///
        /// <value> true if production mode, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonIgnore]
        public bool IsProductionMode
        {
            get
            {
                if (this.Endpoint.Equals(ServiceEndpointEnum.UNDEFINED))
                {
                    SdkConfig appConfig = SdkConfig.Instance;
                    bool tc_sdk_production_mode = false;
                    Boolean.TryParse(appConfig["tc_sdk_production_mode"], out tc_sdk_production_mode);

                    return tc_sdk_production_mode;
                }

                return this.Endpoint.Equals(ServiceEndpointEnum.PRODUCTION);
            }

            set
            {
                this._endpoint = value ? ServiceEndpointEnum.PRODUCTION : ServiceEndpointEnum.INTEGRATION;
            }
        }

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

        public virtual bool execute<T>(ref T response) where T : BaseResponse
        {
            var proxy = new ServiceProxy(this);
            return proxy.Request<T>(ref response);
        }
    }
}
