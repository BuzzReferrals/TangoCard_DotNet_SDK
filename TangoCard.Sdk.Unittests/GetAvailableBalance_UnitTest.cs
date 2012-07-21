using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

using System.Configuration;

using TangoCard.Sdk.Request;
using TangoCard.Sdk.Common;
using TangoCard.Sdk.Response.Success;

namespace TangoCard.Sdk.Unittests
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Get available balance unit test. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\TangoCard.Sdk.dll.config")]
    [DeploymentItem("TangoCard.Sdk.Unittests\\DeploymentItems\\thawte_Server_CA.pem")] 
    public class GetAvailableBalance_UnitTest
    {
        private string app_username = null;
        private string app_password = null;
        private bool is_production_mode = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the available balance unit test initialize. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestInitialize()]
        public void GetAvailableBalance_UnitTest_Initialize()
        {
            this.app_username = ConfigurationManager.AppSettings["app_username"];
            this.app_password = ConfigurationManager.AppSettings["app_password"];

            string app_production_mode = ConfigurationManager.AppSettings["app_production_mode"];
            this.is_production_mode = false;
            Boolean.TryParse(app_production_mode, out this.is_production_mode);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests available balance. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestAvailableBalance_Default()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                var request = new GetAvailableBalanceRequest();
                isSuccess = request.execute(ref response);             
            }
            catch (Exception ex)
            {
                Assert.Fail(message: ex.Message);
            }

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.AvailableBalance >= 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests available balance. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestAvailableBalance_Config()
        {
            bool isSuccess = false;
            GetAvailableBalanceResponse response = null;
            try
            {
                var request = new GetAvailableBalanceRequest
                {
                    Username = this.app_username,
                    Password = this.app_password,
                    IsProductionMode = this.is_production_mode
                };

                isSuccess = request.execute(ref response);
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
    }
}
