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

namespace TangoCard.Sdk.Request
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Request base. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class BaseRequest
    {
        private string username = null;
        private string password = null;
        private int production_mode = -1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the username. </summary>
        ///
        /// <value> The username. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [JsonProperty(PropertyName = "username")]
        public string Username
        {
            get 
            {
                if (String.IsNullOrEmpty(this.username))
                {
                    SdkConfig appConfig = SdkConfig.Instance;
                    return (string)appConfig["tc_sdk_username"];
                }

                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the password. </summary>
        ///
        /// <value> The password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "password")]
        public string Password
        {
            get 
            {
                if (String.IsNullOrEmpty(this.password))
                {
                    SdkConfig appConfig = SdkConfig.Instance;
                    return (string)appConfig["tc_sdk_password"];
                }

                return this.password;
            }

            set
            {
                this.password = value;
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
                if (-1 == this.production_mode)
                {
                    SdkConfig appConfig = SdkConfig.Instance;
                    bool tc_sdk_production_mode = false;
                    Boolean.TryParse(appConfig["tc_sdk_production_mode"], out tc_sdk_production_mode);

                    return tc_sdk_production_mode;
                }

                return (1 == this.production_mode);
            }

            set
            {
                this.production_mode = value ? 1 : 0;
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
            var proxy = new TangoServiceProxy(this);
            return proxy.Request<T>(ref response);
        }
    }
}
