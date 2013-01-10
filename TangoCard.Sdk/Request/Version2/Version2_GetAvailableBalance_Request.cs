//  
//  GetAvailableBalanceRequest.cs
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
using System.Configuration;

using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Response.Success.Version2;
using TangoCard.Sdk.Service;
using TangoCard.Sdk.Common;
using System.Runtime.Serialization;

namespace TangoCard.Sdk.Request.Version2
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Get available balance request. </summary>
    ///
    /// <seealso cref="TangoCard.Sdk.Request.Version2.Version2_Request"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    internal class Version2_GetAvailableBalance_Request : Version2_Request
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="enumTangoCardServiceApi">  The enum tango card service api. </param>
        /// <param name="username">                 The username. </param>
        /// <param name="password">                 The password. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Version2_GetAvailableBalance_Request(
            TangoCardServiceApiEnum enumTangoCardServiceApi,
            string username, 
            string password
            )
            : base(enumTangoCardServiceApi, username, password)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the given out GetAvailableBalanceResponse. </summary>
        ///
        /// <param name="response"> [out] The response. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Execute(out Version2_GetAvailableBalance_Response response)
        {
            string requestSerialized = this.Serialize<Version2_GetAvailableBalance_Request>();
            return base.Execute<Version2_GetAvailableBalance_Response>(requestSerialized, out response);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the full pathname of the request file. </summary>
        ///
        /// <seealso cref="TangoCard.Sdk.Request.BaseRequest.RequestAction"/>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string RequestAction
        {
            get { return "GetAvailableBalance"; }
        }
    }
}
