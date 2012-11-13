//  
//  Version2Request.cs
//  TangoCard_DotNet_SDK
//  
//  Copyright (c) 2012 Tango Card, Inc
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
using System.Runtime.Serialization;
using TangoCard.Sdk.Service;

namespace TangoCard.Sdk.Request.Version2
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Version 2 request. </summary>
    ///
    /// <seealso cref="TangoCard.Sdk.Request.BaseRequest"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public abstract class Version2Request : BaseRequest
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Constructor</summary>
        /// <param name="enumTangoCardServiceApi">The enum tango card service api.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Version2Request(
            TangoCardServiceApiEnum enumTangoCardServiceApi,
            string username, 
            string password
        ) : base(enumTangoCardServiceApi)
        {
            // -----------------------------------------------------------------
            // validate inputs
            // -----------------------------------------------------------------

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

            this.Username = username;
            this.Password = password;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the username. </summary>
        ///
        /// <value> The username. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "username", IsRequired = true)]
        public string Username { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the password. </summary>
        ///
        /// <value> The password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "password", IsRequired = true)]
        public string Password { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the request controller. </summary>
        ///
        /// <seealso cref="TangoCard.Sdk.Request.BaseRequest.RequestController"/>
        ///
        /// ### <value> The request controller. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string RequestController
        {
            get { return "Version2"; }
        }
    }
}
