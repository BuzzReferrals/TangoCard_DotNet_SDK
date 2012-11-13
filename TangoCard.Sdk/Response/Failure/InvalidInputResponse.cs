//  
//  InvalidInputResponse.cs
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
using System.Runtime.Serialization;
using TangoCard.Sdk.Common;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TangoCard.Sdk.Response.Failure
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TangoCard.Sdk.Response.Failure
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Invalid input response. </summary>
    ///
    /// <remarks>   Jeff, 11/13/2012. </remarks>
    ///
    /// <seealso cref="TangoCard.Sdk.Response.Failure.FailureResponse"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InvalidInputResponse : FailureResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the invalid. </summary>
        ///
        /// <value> The invalid. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "invalid")]
        public InvalidInputResponseItems Invalid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the message. </summary>
        ///
        /// <value> The message. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string Message
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                if (this.Invalid.TcSend.IsNotNullNorEmpty())
                {
                    builder.Append(String.Format("tcSend: {0}", this.Invalid.TcSend));
                }
                if (this.Invalid.CardSku.IsNotNullNorEmpty())
                {
                    if (0 < builder.Length)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(String.Format("cardSku: {0}", this.Invalid.CardSku));
                }
                if (this.Invalid.CardValue.IsNotNullNorEmpty())
                {
                    if (0 < builder.Length)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(String.Format("cardValue: {0}", this.Invalid.CardValue));
                }
                if (this.Invalid.RecipientName.IsNotNullNorEmpty())
                {
                    if (0 < builder.Length)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(String.Format("recipientName: {0}", this.Invalid.RecipientName));
                }
                if (this.Invalid.RecipientEmail.IsNotNullNorEmpty())
                {
                    if (0 < builder.Length)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(String.Format("recipientEmail: {0}", this.Invalid.RecipientEmail));
                }
                if (this.Invalid.GiftFrom.IsNotNullNorEmpty())
                {
                    if (0 < builder.Length)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(String.Format("giftFrom: {0}", this.Invalid.GiftFrom));
                }
                if (this.Invalid.CompanyIdentifier.IsNotNullNorEmpty())
                {
                    if (0 < builder.Length)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(String.Format("companyIdentifier: {0}", this.Invalid.CompanyIdentifier));
                }
                return builder.ToString();
            }
            set
            {
                string ignore = value;
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Invalid input response items. </summary>
    ///
    /// <remarks>   Jeff, 11/12/2012. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InvalidInputResponseItems
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the tc send. </summary>
        ///
        /// <value> The tc send. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "tcSend")]
        public string TcSend { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card sku. </summary>
        ///
        /// <value> The card sku. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardSku")]
        public string CardSku { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card value. </summary>
        ///
        /// <value> The card value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardValue")]
        public string CardValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the recipient. </summary>
        ///
        /// <value> The name of the recipient. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "recipientName")]
        public string RecipientName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the recipient email. </summary>
        ///
        /// <value> The recipient email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "recipientEmail")]
        public string RecipientEmail { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gift from. </summary>
        ///
        /// <value> The gift from. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "giftFrom")]
        public string GiftFrom { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the company. </summary>
        ///
        /// <value> The identifier of the company. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "companyIdentifier")]
        public string CompanyIdentifier { get; set; }
    }
}