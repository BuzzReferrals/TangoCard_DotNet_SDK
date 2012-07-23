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

using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Service;

namespace TangoCard.Sdk.Request
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Purchase card request. </summary>
    ///
    /// <seealso cref="TangoCard.Sdk.Request.BaseRequest"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PurchaseCardRequest : BaseRequest
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="username">         The username. </param>
        /// <param name="password">         The password. </param>
        /// <param name="endpoint">         The endpoint. </param>
        /// <param name="cardSku">          The card sku. </param>
        /// <param name="cardValue">        The card value. </param>
        /// <param name="tcSend">           true to tc send. </param>
        /// <param name="recipientName">    Name of the recipient. </param>
        /// <param name="recipientEmail">   The recipient email. </param>
        /// <param name="giftMessage">      Message describing the gift. </param>
        /// <param name="giftFrom">         The gift from. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PurchaseCardRequest(
            string username,
            string password,
            ServiceEndpointEnum endpoint,
            string cardSku,
            int cardValue,
            bool tcSend = false,
            string recipientName = null,
            string recipientEmail = null,
            string giftMessage = null,
            string giftFrom = null
            )
            : base(username, password, endpoint)
        {
            this.CardSku = cardSku;
            this.CardValue = cardValue;
            this.TcSend = tcSend;
            this.RecipientName = recipientName;
            this.RecipientEmail = recipientEmail;
            this.GiftMessage = giftMessage;
            this.GiftFrom = giftFrom;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card sku. </summary>
        ///
        /// <value> The card sku. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "cardSku")]
        public string CardSku { get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card value. </summary>
        ///
        /// <value> The card value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "cardValue")]
        public int CardValue { get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the tc send. </summary>
        ///
        /// <value> true if tc send, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "tcSend")]
        public bool TcSend { get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the recipient. </summary>
        ///
        /// <value> The name of the recipient. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "recipientName")]
        public string RecipientName {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the recipient email. </summary>
        ///
        /// <value> The recipient email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "recipientEmail")]
        public string RecipientEmail {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the gift. </summary>
        ///
        /// <value> A message describing the gift. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "giftMessage")]
        public string GiftMessage { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gift from. </summary>
        ///
        /// <value> The gift from. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "giftFrom")]
        public string GiftFrom {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the full pathname of the request file. </summary>
        ///
        /// <seealso cref="TangoCard.Sdk.Request.BaseRequest.RequestAction"/>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string RequestAction
        {
            get { return "PurchaseCard"; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the execute. </summary>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool execute(ref PurchaseCardResponse response) {
            if (string.IsNullOrEmpty(CardSku))
            {
                throw new ArgumentException("cardSku");
            }

            if (CardSku.Length > 255) 
            {
                throw new ArgumentException("cardSku must have a length less than 255");
            }

            if (CardValue < 1)
            {
                throw new ArgumentException("cardValue must be greater than 1");
            }

            return base.execute<PurchaseCardResponse>(ref response);
        }
    }
}
