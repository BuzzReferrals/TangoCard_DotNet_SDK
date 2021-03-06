﻿//  
//  SystemErrorResponse.cs
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
using System.Text;
using System.Runtime.Serialization;

namespace TangoCard.Sdk.Response.Failure
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   System failure response. </summary>
    ///
    /// <seealso cref="TangoCard.Sdk.Response.Failure.FailureResponse"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SystemErrorResponse : FailureResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the error code. </summary>
        ///
        /// <value> The error code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the message. </summary>
        ///
        /// <value> The message. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string Message
        {
            get
            {
                return String.Format("ErrorCode: {0}", this.ErrorCode);
            }
            set
            {
                string ignore = value;
            }
        }
    }
}
