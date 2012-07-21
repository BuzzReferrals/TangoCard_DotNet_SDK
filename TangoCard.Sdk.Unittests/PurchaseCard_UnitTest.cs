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

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TangoCard.Sdk.Request;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Response.Success;

namespace TangoCard.Sdk.Unittests
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Purchase card unit test. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\TangoCard.Sdk.dll.config")]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\thawte_Server_CA.pem")] 
    public class PurchaseCard_UnitTest
    {
        private string app_username = null;
        private string app_password = null;
        private bool is_production_mode = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the available balance unit test initialize. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestInitialize()]
        public void PurchaseCard_UnitTest_Initialize()
        {
            this.app_username = ConfigurationManager.AppSettings["app_username"];
            this.app_password = ConfigurationManager.AppSettings["app_password"];

            string app_production_mode = ConfigurationManager.AppSettings["app_production_mode"];
            this.is_production_mode = false;
            Boolean.TryParse(app_production_mode, out this.is_production_mode);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests purchase card no delivery default. </summary>
        ///
        /// <remarks>   Jeff, 7/19/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestPurchaseCardNoDelivery_Default()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse responseAvailableBalance = null;
            try
            {
                var request = new GetAvailableBalanceRequest();
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
                var request = new PurchaseCardRequest()
                {
                    CardSku = "tango-card",
                    CardValue = cardValue,
                    TcSend = false
                };

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
                var request = new GetAvailableBalanceRequest();
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
        /// <summary>   Tests purchase card no delivery configuration. </summary>
        ///
        /// <remarks>   Jeff, 7/19/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestPurchaseCardNoDelivery_Config()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                var request = new GetAvailableBalanceRequest
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode
                };
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
                var request = new PurchaseCardRequest()
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode,
                    CardSku = "tango-card",
                    CardValue = cardValue,
                    TcSend = false
                };

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
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode
                };
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
        /// <summary>   Tests purchase card delivery default. </summary>
        ///
        /// <remarks>   Jeff, 7/19/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestPurchaseCardDelivery_Default()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                var request = new GetAvailableBalanceRequest();
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
                var request = new PurchaseCardRequest()
                {
                    CardSku = "tango-card",
                    CardValue = cardValue,            
                    GiftFrom = "From",
                    GiftMessage = "Message",
                    RecipientEmail = "test00tangocard@gmail.com",
                    RecipientName = "Test Tangocard",
                    TcSend = true
                };

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
            Assert.IsNull(cardNumber);

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNull(cardPin);

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
                var request = new GetAvailableBalanceRequest();
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
        ///
        /// <remarks>   Jeff, 7/19/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestPurchaseCardDelivery_Config()
        {
            GetAvailableBalanceResponse responseAvailableBalance = null;
            bool isSuccess = false;
            try
            {
                var request = new GetAvailableBalanceRequest
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode
                };
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
                var request = new PurchaseCardRequest()
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode,
                    CardSku = "tango-card",
                    CardValue = cardValue,
                    GiftFrom = "From",
                    GiftMessage = "Message",
                    RecipientEmail = "test00tangocard@gmail.com",
                    RecipientName = "Test Tangocard",
                    TcSend = true
                };

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
            Assert.IsNull(cardNumber);

            var cardPin = ((PurchaseCardResponse)responsePurchaseCard).CardPin;
            Assert.IsNull(cardPin);

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
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode
                };
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
