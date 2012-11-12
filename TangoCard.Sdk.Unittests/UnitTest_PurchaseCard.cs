//  
//  UnitTest_PurchaseCard.cs
//  TangoCard_DotNet_SDK
//
//  VisualStudio 2010 Unit Test
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TangoCard.Sdk.Request;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Response;
using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Response.Failure;
using TangoCard.Sdk.Service;
using System.Net;

namespace TangoCard.Sdk.Unittests
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Purchase card unit test. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\TangoCard_DotNet_SDK.dll.config")]
    public class UnitTest_PurchaseCard
    {
        private string _app_username = null;
        private string _app_password = null;
        private TangoCardServiceApiEnum _enumTangoCardServiceApi = TangoCardServiceApiEnum.UNDEFINED;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the available balance unit test initialize. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestInitialize()]
        public void TestInitialize_PurchaseCard()
        {
            this._app_username = ConfigurationManager.AppSettings["app_username"];
            this._app_password = ConfigurationManager.AppSettings["app_password"];
            string app_tango_card_service_api = ConfigurationManager.AppSettings["app_tango_card_service_api"];
            this._enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tango_card_service_api);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card invalid credentials. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_InvalidCredentials()
        {
            bool isSuccess = false;

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: "burt@example.com",
                    password: "password",
                    cardSku: "tango-card",
                    cardValue: 100,    // $1.00 value
                    tcSend: false,
                    recipientName: null,
                    recipientEmail: null,
                    giftFrom: null,
                    giftMessage: null,
                    companyIdentifier: null,
                    response: out responsePurchaseCard
                    );

                Assert.Fail(message: "Expected 'TangoCardServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_CREDENTIAL));
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (ArgumentException ex)
            {
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (WebException ex)
            {
                Assert.Fail(message: "WebException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: "Exception: " + ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card invalid credentials nulls. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_InvalidCredentials_Nulls()
        {
            bool isSuccess = false;

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: null,
                    password: null,
                    cardSku: "tango-card",
                    cardValue: 100,    // $1.00 value
                    tcSend: true,
                    recipientName: null,
                    recipientEmail: null,
                    giftFrom: null,
                    giftMessage: null,
                    companyIdentifier: null,
                    response: out responsePurchaseCard
                    );

                Assert.Fail(message: "Expected 'ArgumentException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_CREDENTIAL));
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (ArgumentException ex)
            {
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (WebException ex)
            {
                Assert.Fail(message: "WebException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: "Exception: " + ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card insufficient funds. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_InvalidInputs_Nulls()
        {
            bool isSuccess = false;

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: "empty@tangocard.com",
                        password: "password",
                        cardSku: "tango-card",
                        cardValue: 100,    // $1.00 value
                        tcSend: true,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out responsePurchaseCard
                    );

                Assert.Fail(message: "Expected 'TangoCardServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_INPUT));
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (ArgumentException ex)
            {
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card insufficient funds. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_InsufficientFunds()
        {
            bool isSuccess = false;

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: "empty@tangocard.com",
                        password: "password",
                        cardSku: "tango-card",
                        cardValue: 100,    // $1.00 value
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out responsePurchaseCard
                    );

                Assert.Fail(message: "Expected 'TangoCardServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INS_FUNDS));
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card invalid input. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_InvalidInput_Sku()
        {
            bool isSuccess = false;
            int cardValue = 100; // $1.00 

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: this._app_username,
                        password: this._app_password,
                        cardSku: "mango-card",
                        cardValue: cardValue,
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out responsePurchaseCard
                    );

                Assert.Fail(message: "Expected 'TangoCardServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_INPUT));
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card insufficient funds 10000000. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_InsufficientFunds_10000000()
        {
            bool isSuccess = false;

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: "empty@tangocard.com",
                        password: "password",
                        cardSku: "tango-card",
                        cardValue: 1000000000,    // $100000.00 value
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out responsePurchaseCard
                    );

                Assert.Fail(message: "Expected 'TangoCardServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INS_FUNDS));
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card with no delivery api. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_with_NoDelivery_Api()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseAvailableBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseAvailableBalance);
            Assert.IsTrue(responseAvailableBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance >= 0);
            int availableBalance = ((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance;

            int cardValue = 100; // $1.00 

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    cardSku: "tango-card",
                    cardValue: cardValue,
                    tcSend: false,
                    recipientName: null,
                    recipientEmail: null,
                    giftFrom: null,
                    giftMessage: null,
                    companyIdentifier: null,
                    response: out responsePurchaseCard
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responsePurchaseCard);
            Assert.IsTrue(responsePurchaseCard is PurchaseCardResponse);

            var referenceOrderId = ((PurchaseCardResponse)responsePurchaseCard).ReferenceOrderId;
            Assert.IsNotNull(referenceOrderId);
            Assert.IsTrue(referenceOrderId is String);
            Assert.IsTrue(!String.IsNullOrEmpty(referenceOrderId));

            var cardToken = ((PurchaseCardResponse)responsePurchaseCard).CardToken;
            Assert.IsNotNull(cardToken);
            Assert.IsTrue(cardToken is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardToken));

            var cardNumber = ((PurchaseCardResponse)responsePurchaseCard).CardNumber;
            Assert.IsNotNull(cardNumber);
            Assert.IsTrue(cardNumber is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardNumber));

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNotNull(cardPin);
            Assert.IsTrue(cardPin is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardPin));

            GetAvailableBalanceResponse responseUpdatedBalance = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseUpdatedBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseUpdatedBalance);
            Assert.IsTrue(responseUpdatedBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance >= 0);
            int updatedBalance = ((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance;

            Assert.AreNotEqual(availableBalance, updatedBalance);
            Assert.IsTrue(availableBalance - cardValue == updatedBalance);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card with no delivery. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_with_NoDelivery()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseAvailableBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseAvailableBalance);
            Assert.IsTrue(responseAvailableBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance >= 0);
            int availableBalance = ((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance;

            int cardValue = 100; // $1.00 

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: this._app_username,
                        password: this._app_password,
                        cardSku: "tango-card",
                        cardValue: cardValue,
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out responsePurchaseCard
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responsePurchaseCard);
            Assert.IsTrue(responsePurchaseCard is PurchaseCardResponse);

            var referenceOrderId = ((PurchaseCardResponse)responsePurchaseCard).ReferenceOrderId;
            Assert.IsNotNull(referenceOrderId);
            Assert.IsTrue(referenceOrderId is String);
            Assert.IsTrue(!String.IsNullOrEmpty(referenceOrderId));

            var cardToken = ((PurchaseCardResponse)responsePurchaseCard).CardToken;
            Assert.IsNotNull(cardToken);
            Assert.IsTrue(cardToken is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardToken));

            var cardNumber = ((PurchaseCardResponse)responsePurchaseCard).CardNumber;
            Assert.IsNotNull(cardNumber);
            Assert.IsTrue(cardNumber is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardNumber));

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNotNull(cardPin);
            Assert.IsTrue(cardPin is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardPin));

            GetAvailableBalanceResponse responseUpdatedBalance = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseUpdatedBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseUpdatedBalance);
            Assert.IsTrue(responseUpdatedBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance >= 0);
            int updatedBalance = ((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance;

            Assert.AreNotEqual(availableBalance, updatedBalance);
            Assert.IsTrue(availableBalance - cardValue == updatedBalance);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card optional company identifer. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_OptionalCompanyIdentifer()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseAvailableBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseAvailableBalance);
            Assert.IsTrue(responseAvailableBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance >= 0);
            int availableBalance = ((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance;

            int cardValue = 100; // $1.00 

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: this._app_username,
                        password: this._app_password,
                        cardSku: "tango-card",
                        cardValue: cardValue,
                        tcSend: true,
                        giftFrom: "Bill Support",
                        giftMessage: "Hello from Tango Card C#/.NET SDK:\nTango Card\nPhone: 1-877-55-TANGO\n601 Union Street, Suite 4200\nSeattle, WA 98101",
                        recipientEmail: "sally@example.com",
                        recipientName: "Sally Customer",
                        companyIdentifier: "BigFoodStore",
                        response: out responsePurchaseCard
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responsePurchaseCard);
            Assert.IsTrue(responsePurchaseCard is PurchaseCardResponse);

            var referenceOrderId = ((PurchaseCardResponse)responsePurchaseCard).ReferenceOrderId;
            Assert.IsNotNull(referenceOrderId);
            Assert.IsTrue(referenceOrderId is String);
            Assert.IsTrue(!String.IsNullOrEmpty(referenceOrderId));

            var cardToken = ((PurchaseCardResponse)responsePurchaseCard).CardToken;
            Assert.IsNotNull(cardToken);
            Assert.IsTrue(cardToken is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardToken));

            var cardNumber = ((PurchaseCardResponse)responsePurchaseCard).CardNumber;
            Assert.IsNotNull(cardNumber);
            Assert.IsTrue(cardNumber is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardNumber));

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNotNull(cardPin);
            Assert.IsTrue(cardPin is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardPin));

            GetAvailableBalanceResponse responseUpdatedBalance = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseUpdatedBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseUpdatedBalance);
            Assert.IsTrue(responseUpdatedBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance >= 0);
            int updatedBalance = ((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance;

            Assert.AreNotEqual(availableBalance, updatedBalance);
            Assert.IsTrue(availableBalance - cardValue == updatedBalance);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card with delivery. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_with_Delivery()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseAvailableBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseAvailableBalance);
            Assert.IsTrue(responseAvailableBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance >= 0);
            int availableBalance = ((GetAvailableBalanceResponse)responseAvailableBalance).AvailableBalance;

            int cardValue = 100; // $1.00 

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                isSuccess = TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: this._app_username,
                        password: this._app_password,
                        cardSku: "tango-card",
                        cardValue: cardValue,
                        tcSend: true,
                        giftFrom: "Bill Support",
                        giftMessage: "Hello from Tango Card C#/.NET SDK:\nTango Card\nPhone: 1-877-55-TANGO\n601 Union Street, Suite 4200\nSeattle, WA 98101",
                        recipientEmail: "sally@example.com",
                        recipientName: "Sally Customer",
                        companyIdentifier: null,
                        response: out responsePurchaseCard
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responsePurchaseCard);
            Assert.IsTrue(responsePurchaseCard is PurchaseCardResponse);

            var referenceOrderId = ((PurchaseCardResponse)responsePurchaseCard).ReferenceOrderId;
            Assert.IsNotNull(referenceOrderId);
            Assert.IsTrue(referenceOrderId is String);
            Assert.IsTrue(!String.IsNullOrEmpty(referenceOrderId));

            var cardToken = ((PurchaseCardResponse)responsePurchaseCard).CardToken;
            Assert.IsNotNull(cardToken);
            Assert.IsTrue(cardToken is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardToken));

            var cardNumber = ((PurchaseCardResponse)responsePurchaseCard).CardNumber;
            Assert.IsNotNull(cardNumber);
            Assert.IsTrue(cardNumber is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardNumber));

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNotNull(cardPin);
            Assert.IsTrue(cardPin is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardPin));

            GetAvailableBalanceResponse responseUpdatedBalance = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out responseUpdatedBalance
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responseUpdatedBalance);
            Assert.IsTrue(responseUpdatedBalance is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance >= 0);
            int updatedBalance = ((GetAvailableBalanceResponse)responseUpdatedBalance).AvailableBalance;

            Assert.AreNotEqual(availableBalance, updatedBalance);
            Assert.IsTrue(availableBalance - cardValue == updatedBalance);
        }
    }
}
