﻿//  
//  PurchaseCardRequest.cs
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
using System.Configuration;

using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Response.Success.Version2;
using TangoCard.Sdk.Service;
using TangoCard.Sdk.Common;
using System.Runtime.Serialization;

namespace TangoCard.Sdk.Request.Version2
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Purchase card request. </summary>
    ///
    /// <seealso cref="TangoCard.Sdk.Request.Version2.Version2_Request"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    internal class Version2_PurchaseCard_Request : Version2_Request
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        ///
        /// <param name="enumTangoCardServiceApi">  The enum tango card service api. </param>
        /// <param name="username">                 The username. </param>
        /// <param name="password">                 The password. </param>
        /// <param name="cardSku">                  The card sku. </param>
        /// <param name="cardValue">                The card value. </param>
        /// <param name="tcSend">                   Determines if Tango Card Service will send an email with gift card information to recipient. </param>
        /// <param name="recipientName">            (optional) The name of the recipient. </param>
        /// <param name="recipientEmail">           (optional) The recipient email. </param>
        /// <param name="giftMessage">              (optional) The gift message. </param>
        /// <param name="giftFrom">                 (optional) The gift from. </param>
        /// <param name="companyIdentifier">        (optional) The Company identifier for which Email Template to use when sending Gift Card. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Version2_PurchaseCard_Request(
            TangoCardServiceApiEnum enumTangoCardServiceApi,
            string username,
            string password,
            string cardSku,
            int cardValue,
            bool tcSend = false,
            string recipientName = null,
            string recipientEmail = null,
            string giftMessage = null,
            string giftFrom = null,
            string companyIdentifier = null
            )
            : base(enumTangoCardServiceApi, username, password)
        {
            // -----------------------------------------------------------------
            // validate inputs
            // ----------------------------------------------------------------- 

            // cardSku
            if (String.IsNullOrEmpty(cardSku))
            {
                throw new ArgumentNullException(paramName: "cardSku");
            }
            if (cardSku.Length < 1)
            {
                throw new ArgumentException(message: "Parameter 'cardSku' must have a length greater than zero.");
            }
            if (cardSku.Length > 255)
            {
                throw new ArgumentException(message: "Parameter 'cardSku' must have a length less than 255.");
            }

            // cardValue
            if (cardValue < 1)
            {
                throw new ArgumentException(message: "Parameter 'cardValue' must have a value which is greater than or equal to 1.");
            }

            if (tcSend)
            {
                // recipientName
                if (String.IsNullOrEmpty(recipientName))
                {
                    throw new ArgumentNullException(paramName: "recipientName");
                }
                if (recipientName.Length < 1)
                {
                    throw new ArgumentException(message: "Parameter 'recipientName' must have a length greater than zero.");
                }
                if (recipientName.Length > 255)
                {
                    throw new ArgumentException(message: "Parameter 'recipientName' must have a length less than 256.");
                }

                // recipientEmail
                if (String.IsNullOrEmpty(recipientEmail))
                {
                    throw new ArgumentNullException(paramName: "recipientEmail");
                }
                if (recipientEmail.Length < 3)
                {
                    throw new ArgumentException(message: "Parameter 'recipientEmail' must have a length greater than two.");
                }
                if (recipientEmail.Length > 255)
                {
                    throw new ArgumentException(message: "Parameter 'recipientEmail' must have a length less than 256.");
                }

                // giftFrom
                if (String.IsNullOrEmpty(giftFrom))
                {
                    throw new ArgumentNullException(paramName: "giftFrom");
                }
                if (giftFrom.Length < 1)
                {
                    throw new ArgumentException(message: "Parameter 'giftFrom' must have a length greater than zero.");
                }
                if (giftFrom.Length > 255)
                {
                    throw new ArgumentException(message: "Parameter 'giftFrom' must have a length less than 256.");
                }

                // giftMessage
                if (!String.IsNullOrEmpty(giftMessage))
                {
                    if (giftMessage.Length > 255)
                    {
                        throw new ArgumentException(message: "Parameter 'giftMessage' must have a length less than 256.");
                    }
                }

                // companyIdentifier
                if (!String.IsNullOrEmpty(companyIdentifier))
                {
                    if (companyIdentifier.Length > 255)
                    {
                        throw new ArgumentException(message: "Parameter 'companyIdentifier' must have a length less than 256.");
                    }
                }
            }

            // -----------------------------------------------------------------
            // save inputs
            // -----------------------------------------------------------------

            this.CardSku = cardSku;
            this.CardValue = cardValue;
            this.TcSend    = tcSend;
            if (tcSend) {
                this.RecipientName  = recipientName; 
                this.RecipientEmail = recipientEmail;
                this.GiftFrom       = giftFrom;
                if (!String.IsNullOrEmpty(giftMessage))
                {
                    this.GiftMessage = giftMessage;
                }
                if (!String.IsNullOrEmpty(companyIdentifier))
                {
                    this.CompanyIdentifier = companyIdentifier;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card sku. </summary>
        ///
        /// <value> The card sku. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardSku", IsRequired = true)]
        public string CardSku { get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card value. </summary>
        ///
        /// <value> The card value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardValue", IsRequired = true)]
        public int CardValue { get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the tc send. </summary>
        ///
        /// <value> true if tc send, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "tcSend", IsRequired = true)]
        public bool TcSend { get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the recipient. </summary>
        ///
        /// <value> The name of the recipient. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "recipientName", EmitDefaultValue = false, IsRequired = false)]
        public string RecipientName {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the recipient email. </summary>
        ///
        /// <value> The recipient email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "recipientEmail", EmitDefaultValue = false, IsRequired = false)]
        public string RecipientEmail {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the gift. </summary>
        ///
        /// <value> A message describing the gift. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "giftMessage", EmitDefaultValue = false, IsRequired = false)]
        public string GiftMessage { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gift from. </summary>
        ///
        /// <value> The gift from. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "giftFrom", EmitDefaultValue = false, IsRequired = false)]
        public string GiftFrom {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the company identifier which determines which email template to use. </summary>
        ///
        /// <value> The company identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "companyIdentifier", EmitDefaultValue = false, IsRequired = false)]
        public string CompanyIdentifier { get; set; }

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
        /// <summary>   Executes the given out PurchaseCardResponse. </summary>
        ///
        /// <param name="response"> [out] The response. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Execute(out Version2_PurchaseCard_Response response) 
        {
            string requestSerialized = this.Serialize<Version2_PurchaseCard_Request>();
            return base.Execute<Version2_PurchaseCard_Response>(requestSerialized, out response);
        }
    }
}
