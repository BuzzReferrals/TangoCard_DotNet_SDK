//  
//  PurchaseCardRequest.cs
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
        /// <remarks>   Jeff, 7/24/2012. </remarks>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <param name="isProductionMode">     true if this object is production mode. </param>
        /// <param name="username">             The username. </param>
        /// <param name="password">             The password. </param>
        /// <param name="companyIdentifier">    Identifier for the company. </param>
        /// <param name="cardSku">              The card sku. </param>
        /// <param name="cardValue">            The card value. </param>
        /// <param name="tcSend">               true to tc send. </param>
        /// <param name="recipientName">        Name of the recipient. </param>
        /// <param name="recipientEmail">       The recipient email. </param>
        /// <param name="giftMessage">          Message describing the gift. </param>
        /// <param name="giftFrom">             The gift from. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PurchaseCardRequest(
            bool isProductionMode,
            string username,
            string password,
            string companyIdentifier,
            string cardSku,
            int cardValue,
            bool tcSend = false,
            string recipientName = null,
            string recipientEmail = null,
            string giftMessage = null,
            string giftFrom = null
            )
            : base(isProductionMode, username, password)
        {
            // -----------------------------------------------------------------
            // validate inputs
            // ----------------------------------------------------------------- 
            // companyIdentifier
            if (String.IsNullOrEmpty(companyIdentifier))
            {
                throw new ArgumentException("companyIdentifier must be a string.");
            }
            if (companyIdentifier.Length < 1)
            {
                throw new ArgumentException("companyIdentifier must have a length greater than zero.");
            }
            if (companyIdentifier.Length > 255)
            {
                throw new ArgumentException("companyIdentifier must have a length less than 255.");
            }       
            // cardSku
            if (String.IsNullOrEmpty(cardSku))
            {
                throw new ArgumentException("cardSku must be a string.");
            }
            if (cardSku.Length < 1)
            {
                throw new ArgumentException("cardSku must have a length greater than zero.");
            }
            if (cardSku.Length > 255)
            {
                throw new ArgumentException("cardSku must have a length less than 255.");
            }
            // cardValue
            if (cardValue < 1)
            {
                throw new ArgumentException("cardValue must have a value which is greater than zero.");
            }
            if (cardValue > 10000)
            {
                throw new ArgumentException("cardValue must have a value which is less than 10000.");
            }
            if (tcSend)
            {
                // recipientName
                if (String.IsNullOrEmpty(recipientName))
                {
                    throw new ArgumentException("recipientName must be present (not null) if tcSend is set to true.");
                }
                if (recipientName.Length < 1)
                {
                    throw new ArgumentException("recipientName must have a length greater than zero.");
                }
                if (recipientName.Length > 255)
                {
                    throw new ArgumentException("recipientName must have a length less than 256.");
                }
                // recipientEmail
                if (String.IsNullOrEmpty(recipientEmail))
                {
                    throw new ArgumentException("recipientEmail must be present (not null) if tcSend is set to true.");
                }
                if (recipientEmail.Length < 3)
                {
                    throw new ArgumentException("recipientEmail must have a length greater than two.");
                }
                if (recipientEmail.Length > 255)
                {
                    throw new ArgumentException("recipientEmail must have a length less than 256.");
                }
                // giftMessage
                if (String.IsNullOrEmpty(giftMessage))
                {
                    throw new ArgumentException("giftMessage must be present (not null) if tcSend is set to true.");
                }
                if (giftMessage.Length < 1)
                {
                    throw new ArgumentException("giftMessage must have a length greater than zero.");
                }
                if (giftMessage.Length > 255)
                {
                    throw new ArgumentException("giftMessage must have a length less than 256.");
                }
                // giftFrom
                if (String.IsNullOrEmpty(giftFrom))
                {
                    throw new ArgumentException("giftFrom must be present (not null) if tcSend is set to true.");
                }
                if (giftFrom.Length < 1)
                {
                    throw new ArgumentException("giftFrom must have a length greater than zero.");
                }
                if (giftFrom.Length > 255)
                {
                    throw new ArgumentException("giftFrom must have a length less than 256.");
                }
            }

            // -----------------------------------------------------------------
            // save inputs
            // -----------------------------------------------------------------
            this.CompanyIdentifier = companyIdentifier;
            this.CardSku = cardSku;
            this.CardValue = cardValue;
            this.TcSend    = tcSend;
            if (tcSend) {
                this.RecipientName  = recipientName; 
                this.RecipientEmail = recipientEmail;
                this.GiftMessage    = giftMessage;
                this.GiftFrom       = giftFrom;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the company. </summary>
        ///
        /// <value> The identifier of the company. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [JsonProperty(PropertyName = "company_identifier")]
        public string CompanyIdentifier { get; set; }

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

        public bool execute(ref PurchaseCardResponse response) 
        {
            return base.execute<PurchaseCardResponse>(ref response);
        }
    }
}
