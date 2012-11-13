//
//  PurchaseCardResponse.cs
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

namespace TangoCard.Sdk.Response.Success.Version2
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Purchase card response. </summary>
    ///
    /// <remarks>   Jeff, 11/12/2012. </remarks>
    ///
    /// <seealso cref="TangoCard.Sdk.Response.Success.SuccessResponse"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PurchaseCardResponse : SuccessResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the reference order. </summary>
        ///
        /// <value> The identifier of the reference order. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "referenceOrderId")]
        public string ReferenceOrderId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card token. </summary>
        ///
        /// <value> The card token. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardToken")]
        public string CardToken { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   If available, gets or sets the card number. </summary>
        ///
        /// <value> The card number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardNumber")]
        public string CardNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   If available, gets or sets the card pin. </summary>
        ///
        /// <value> The card pin. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "cardPin")]
        public string CardPin { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   If available, gets or sets URL of the claim. </summary>
        ///
        /// <value> The claim url. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "claimUrl")]
        public string ClaimUrl { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   If available, gets or sets the challenge key. </summary>
        ///
        /// <value> The challenge key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "challengeKey")]
        public string ChallengeKey { get; set; }
    }
}
