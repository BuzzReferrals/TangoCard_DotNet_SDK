//  
//  UnitTest_GetAvailableBalance.cs
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
// 

using System;
using System.Text;
using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TangoCard.Sdk.Request;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Response;
using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Response.Success.Version2;
using TangoCard.Sdk.Response.Failure;
using TangoCard.Sdk.Service;

namespace TangoCard.Sdk.Unittests.Version2
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Get available balance unit test. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\TangoCard_DotNet_SDK.dll.config")]
    public class Version2_GetAvailableBalance_Test
    {
        private string _app_username = null;
        private string _app_password = null;
        private TangoCardServiceApiEnum _enumTangoCardServiceApi = TangoCardServiceApiEnum.UNDEFINED;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the available balance unit test initialize. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestInitialize()]
        public void TestInitialize_GetAvailableBalance()
        {
            this._app_username = ConfigurationManager.AppSettings["app_username"];
            this._app_password = ConfigurationManager.AppSettings["app_password"];

            string app_tango_card_service_api = ConfigurationManager.AppSettings["app_tango_card_service_api"];
            this._enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tango_card_service_api);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests get available balance api. </summary>
        ///
        /// <remarks>   Jeff, 7/30/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_GetAvailableBalance_Api()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                    enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                    username: this._app_username,
                    password: this._app_password,
                    response: out response
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(response);
            Assert.IsTrue(response is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)response).AvailableBalance >= 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests get available balance request. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_GetAvailableBalance_Request()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: this._app_username,
                        password: this._app_password,
                        response: out response);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(response);
            Assert.IsTrue(response is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)response).AvailableBalance >= 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests get available balance invalid credentials. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_GetAvailableBalance_InvalidCredentials()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: "burt@example.com",
                        password: "password",
                        response: out response);

                Assert.Fail(message: "Expected 'TangoCardServiceException' thrown");
            }
            catch (TangoCardServiceException ex)
            {
                Assert.IsTrue( condition: ex.ResponseType.Equals(ServiceResponseEnum.INV_CREDENTIAL) );
                string message = ex.Message;
                Assert.IsNotNull(message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(response);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests get available balance invalid inputs nulls. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2012. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_GetAvailableBalance_InvalidInputs_Nulls()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: null,
                        password: null,
                        response: out response);

                Assert.Fail(message: "Expected 'ArgumentNullException' thrown");
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
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsFalse(isSuccess);
            Assert.IsNull(response);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests get available balance insufficient funds. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_GetAvailableBalance_InsufficientFunds()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                isSuccess = TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: this._enumTangoCardServiceApi,
                        username: "empty@tangocard.com",
                        password: "password",
                        response: out response);
            }
            catch (TangoCardServiceException ex)
            {
                Assert.Fail(message: ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(response);
            Assert.IsTrue(response is GetAvailableBalanceResponse);
            Assert.IsTrue(((GetAvailableBalanceResponse)response).AvailableBalance == 0);
        }
    }
}
