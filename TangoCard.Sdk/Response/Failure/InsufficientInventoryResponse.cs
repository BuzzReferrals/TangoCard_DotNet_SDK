//  
//  InsufficientInventoryResponse.cs
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
using Newtonsoft.Json;

namespace TangoCard.Sdk.Response.Failure
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Insufficient inventory response. </summary>
    ///
    /// <seealso cref="TangoCard.Sdk.Response.Failure.FailureResponse"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InsufficientInventoryResponse : FailureResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sku. </summary>
        ///
        /// <value> The sku. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value. </summary>
        ///
        /// <value> The value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the message. </summary>
        ///
        /// <value> The message. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string Message
        {
            get
            {
                return String.Format("SKU {0}, Value {1}", this.Sku, this.Value);
            }
            set
            {
                string ignore = value;
            }
        }
    }
}
