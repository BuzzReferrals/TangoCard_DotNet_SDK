//  
//  UnitTest_PurchaseCard.cs
//  TangoCard_DotNet_SDK
//
//  VisualStudio 2010 Unit Test
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
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\TangoCard.Sdk.dll.config")]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\thawte_Server_CA.pem")] 
    public class UnitTest_PurchaseCard
    {
        private string _app_username = null;
        private string _app_password = null;
        private bool _is_production_mode = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the available balance unit test initialize. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestInitialize()]
        public void TestInitialize_PurchaseCard()
        {
            this._app_username = ConfigurationManager.AppSettings["app_username"];
            this._app_password = ConfigurationManager.AppSettings["app_password"];
            string app_production_mode = ConfigurationManager.AppSettings["app_production_mode"];
            this._is_production_mode = false;
            Boolean.TryParse(app_production_mode, out this._is_production_mode);
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
                var request = new PurchaseCardRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: "test@test.com",
                    password: "password",
                    cardSku: "tango-card",
                    cardValue: 100,    // $1.00 value
                    tcSend: false
                );

                isSuccess = request.execute(ref responsePurchaseCard);

                Assert.Fail(message: "Expected 'ServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_CREDENTIAL));
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(message: "ArgumentException: " + ex.Message);
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
        public void Test_PurchaseCard_InsufficientFunds()
        {
            bool isSuccess = false;

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                var request = new PurchaseCardRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: "empty@tangocard.com",
                    password: "password",
                    cardSku: "tango-card",
                    cardValue: 100,    // $1.00 value
                    tcSend: false
                );

                isSuccess = request.execute(ref responsePurchaseCard);

                Assert.Fail(message: "Expected 'ServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INS_FUNDS));
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
        public void Test_PurchaseCard_InvalidInput()
        {
            bool isSuccess = false;
            int cardValue = 100; // $1.00 

            PurchaseCardResponse responsePurchaseCard = null;
            try
            {
                var request = new PurchaseCardRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password,
                    cardSku: "mango-card",
                    cardValue: cardValue,
                    tcSend: false
                );

                isSuccess = request.execute(ref responsePurchaseCard);

                Assert.Fail(message: "Expected 'ServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue(condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_INPUT));
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(responsePurchaseCard);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card no delivery configuration. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_NoDelivery_Config()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                var request = new GetAvailableBalanceRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password
                );
                isSuccess = request.execute(ref responseAvailableBalance);
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
                var request = new PurchaseCardRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password,
                    cardSku: "tango-card",
                    cardValue: cardValue,
                    tcSend: false
                );

                isSuccess = request.execute(ref responsePurchaseCard);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responsePurchaseCard);
            Assert.IsTrue(responsePurchaseCard is PurchaseCardResponse);

            var cardNumber = ((PurchaseCardResponse)responsePurchaseCard).CardNumber;
            Assert.IsNotNull(cardNumber);
            Assert.IsTrue(cardNumber is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardNumber));

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNotNull(cardPin);
            Assert.IsTrue(cardPin is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardPin));

            var cardToken = ((PurchaseCardResponse)responsePurchaseCard).CardToken;
            Assert.IsNotNull(cardToken);
            Assert.IsTrue(cardToken is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardToken));

            var referenceOrderId = ((PurchaseCardResponse)responsePurchaseCard).ReferenceOrderId;
            Assert.IsNotNull(referenceOrderId);
            Assert.IsTrue(referenceOrderId is String);
            Assert.IsTrue(!String.IsNullOrEmpty(referenceOrderId));

            GetAvailableBalanceResponse responseUpdatedBalance = null;
            try
            {
                var request = new GetAvailableBalanceRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password
                );
                isSuccess = request.execute(ref responseUpdatedBalance);
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
        /// <summary>   Tests purchase card delivery configuration. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_PurchaseCard_Delivery_Config()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                var request = new GetAvailableBalanceRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password
                );
                isSuccess = request.execute(ref responseAvailableBalance);
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
                var request = new PurchaseCardRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password,
                    cardSku: "tango-card",
                    cardValue: cardValue,
                    tcSend: true,
                    giftFrom: "Bill Test Giver",
                    giftMessage: "Happy Birthday",
                    recipientEmail: "sue_test_recipient@test.com",
                    recipientName: "Sue Test Recipient"
                );

                isSuccess = request.execute(ref responsePurchaseCard);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(responsePurchaseCard);
            Assert.IsTrue(responsePurchaseCard is PurchaseCardResponse);

            var cardNumber = ((PurchaseCardResponse)responsePurchaseCard).CardNumber;
            Assert.IsNotNull(cardNumber);

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNotNull(cardPin);

            var cardToken = ((PurchaseCardResponse)responsePurchaseCard).CardToken;
            Assert.IsNotNull(cardToken);
            Assert.IsTrue(cardToken is String);
            Assert.IsTrue(!String.IsNullOrEmpty(cardToken));

            var referenceOrderId = ((PurchaseCardResponse)responsePurchaseCard).ReferenceOrderId;
            Assert.IsNotNull(referenceOrderId);
            Assert.IsTrue(referenceOrderId is String);
            Assert.IsTrue(!String.IsNullOrEmpty(referenceOrderId));

            GetAvailableBalanceResponse responseUpdatedBalance = null;
            try
            {
                var request = new GetAvailableBalanceRequest
                (
                    isProductionMode: this._is_production_mode,
                    username: this._app_username,
                    password: this._app_password
                );
                isSuccess = request.execute(ref responseUpdatedBalance);
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
