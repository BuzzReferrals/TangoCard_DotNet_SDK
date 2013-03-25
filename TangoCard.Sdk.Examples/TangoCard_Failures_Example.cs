//  
//  TangoCard_Failures_Example.cs
//  TangoCard_DotNet_SDK
//  
//  Example code using Tango Card SDK forcing failures and then collecting responses.
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
// 


using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using TangoCard.Sdk.Common;
using TangoCard.Sdk.Request;
using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Response.Success.Version2;
using TangoCard.Sdk.Service;
using TangoCard.Sdk.Response.Failure;
using TangoCard.Sdk.Response;

namespace TangoCard.Sdk.Examples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Tango card failures example. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class TangoCard_Failures_Example
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes this object. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public void Execute()
        {
            Console.WriteLine("\n===============================");
            Console.WriteLine(  "= Tango Card .NET SDK Example =");
            Console.WriteLine(  "=   with Failures             =");
            Console.WriteLine(  "===============================\n");

            Console.WriteLine(String.Format("SDK Version: {0}\n", TangoCardServiceApi.GetVersion()));

            TangoCard_Failures_Example.Example_GetAvailableBalance_InvalidCredentials();
            TangoCard_Failures_Example.Example_PurchaseCard_InsufficientFunds();
            TangoCard_Failures_Example.Example_PurchaseCard_InvalidInput_Sku();
            TangoCard_Failures_Example.Example_PurchaseCard_InsufficientFunds_1000000000();

            Console.WriteLine("\n===============================");
            Console.WriteLine(  "=   The End                   =");
            Console.WriteLine(  "===============================");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the available balance invalid credentials. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public void Example_GetAvailableBalance_InvalidCredentials()
        {
            Console.WriteLine("== Using app.config Credentials ====\n");

            string app_tc_sdk_environment = ConfigurationManager.AppSettings["app_tc_sdk_environment"];
            TangoCardServiceApiEnum enumTangoCardServiceApi = (TangoCardServiceApiEnum) Enum.Parse(typeof(TangoCardServiceApiEnum), app_tc_sdk_environment);

           string username = "burt@example.com";
           string password = "password";

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Get Available Balance ========");

                Version2_GetAvailableBalance_Response response = null;
                if (TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: username,
                        password: password,
                        response: out response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Expected failure ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (TangoCardServiceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Tango Card Service Failure ===");
                Console.WriteLine("Failure response type: {0}", ex.ResponseType.ToString());
                Console.WriteLine("Failure response:      {0}", ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (TangoCardSdkException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Tango Card SDK Failure ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Unexpected Error ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Available Balance ====\n\n\n");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Example purchase card insufficient funds. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public void Example_PurchaseCard_InsufficientFunds()
        {
            Console.WriteLine("== Using app.config Credentials ====\n");

            string app_tc_sdk_environment = ConfigurationManager.AppSettings["app_tc_sdk_environment"];
            TangoCardServiceApiEnum enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tc_sdk_environment);

            string username = "empty@tangocard.com";
            string password = "password";

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Purchase Card ========");

                Version2_PurchaseCard_Response response = null;
                if (TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: username,
                        password: password,
                        cardSku: "tango-card",
                        cardValue: 100,    // $1.00 value
                        tcSend: false,
                        recipientName: null,
                        recipientEmail: null,
                        giftFrom: null,
                        giftMessage: null,
                        companyIdentifier: null,
                        response: out response
                    )  
                    && (null != response)
                ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Expected failure ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (TangoCardServiceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Tango Card Service Failure ===");
                Console.WriteLine("Failure response type: {0}", ex.ResponseType.ToString());
                Console.WriteLine("Failure response:      {0}", ex.Message);
                if ( ex.ResponseType.Equals( ServiceResponseEnum.INS_FUNDS ) ) {
                    Console.WriteLine("AvailableBalance:      {0}", ((InsufficientFundsResponse)ex.Response).AvailableBalance);
                    Console.WriteLine("OrderCost:             {0}", ((InsufficientFundsResponse)ex.Response).OrderCost);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (TangoCardSdkException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Tango Card SDK Failure ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Unexpected Error ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Purchase Card ====\n\n\n");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Example purchase card invalid input sku. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public void Example_PurchaseCard_InvalidInput_Sku()
        {
            string app_tc_sdk_environment = ConfigurationManager.AppSettings["app_tc_sdk_environment"];
            TangoCardServiceApiEnum enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tc_sdk_environment);

            string app_username = ConfigurationManager.AppSettings["app_username"];
            string app_password = ConfigurationManager.AppSettings["app_password"];

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Purchase Card ========");

                Version2_PurchaseCard_Response response = null;
                if (TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        cardSku: "mango-card",
                        cardValue: 100,    // $1.00 value
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out response
                    )
                    && (null != response)
                ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Expected failure ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (TangoCardServiceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Tango Card Service Failure ===");
                Console.WriteLine("Failure response type: {0}", ex.ResponseType.ToString());
                Console.WriteLine("Failure response:      {0}", ex.Message);
                if (ex.ResponseType.Equals(ServiceResponseEnum.INV_INPUT))
                {
                    Console.WriteLine("Invalid:      {0}", ((InvalidInputResponse)ex.Response).Message );
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (TangoCardSdkException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Tango Card SDK Failure ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Unexpected Error ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Purchase Card ====\n\n\n");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Example purchase card insufficient funds. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public void Example_PurchaseCard_InsufficientFunds_1000000000()
        {

            int cardValue = 1000000000; // $10000000.00

            string app_tc_sdk_environment = ConfigurationManager.AppSettings["app_tc_sdk_environment"];
            TangoCardServiceApiEnum enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tc_sdk_environment);

            string app_username = ConfigurationManager.AppSettings["app_username"];
            string app_password = ConfigurationManager.AppSettings["app_password"];

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Purchase Card ========");

                Version2_PurchaseCard_Response response = null;
                if (TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        cardSku: "amazon-gift-card",
                        cardValue: cardValue,
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out response
                    )
                    && (null != response)
                )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Expected failure ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (TangoCardServiceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Tango Card Service Failure ===");
                Console.WriteLine("Failure response type: {0}", ex.ResponseType.ToString());
                Console.WriteLine("Failure response:      {0}", ex.Message);
                if (ex.ResponseType.Equals(ServiceResponseEnum.INS_FUNDS))
                {
                    Console.WriteLine("AvailableBalance:      {0}", ((InsufficientFundsResponse)ex.Response).AvailableBalance);
                    Console.WriteLine("OrderCost:             {0}", ((InsufficientFundsResponse)ex.Response).OrderCost);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (TangoCardSdkException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Tango Card SDK Failure ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Unexpected Error ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Purchase Card ====\n\n\n");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Example purchase card insufficient funds. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public void Example_PurchaseCard_Sku()
        {
            int cardValue = 123; // $10000000.00

            string app_tc_sdk_environment = ConfigurationManager.AppSettings["app_tc_sdk_environment"];
            TangoCardServiceApiEnum enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tc_sdk_environment);

            string app_username = ConfigurationManager.AppSettings["app_username"];
            string app_password = ConfigurationManager.AppSettings["app_password"];

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Purchase Card ========");

                Version2_PurchaseCard_Response response = null;
                if (TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        cardSku: "tango-card",
                        cardValue: cardValue,
                        tcSend: false,
                        giftFrom: null,
                        giftMessage: null,
                        recipientEmail: null,
                        recipientName: null,
                        companyIdentifier: null,
                        response: out response
                    )
                    && (null != response)
                )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Expected failure ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (TangoCardServiceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Tango Card Service Failure ===");
                Console.WriteLine("Failure response type: {0}", ex.ResponseType.ToString());
                Console.WriteLine("Failure response:      {0}", ex.Message);
                if (ex.ResponseType.Equals(ServiceResponseEnum.INS_FUNDS))
                {
                    Console.WriteLine("AvailableBalance:      {0}", ((InsufficientFundsResponse)ex.Response).AvailableBalance);
                    Console.WriteLine("OrderCost:             {0}", ((InsufficientFundsResponse)ex.Response).OrderCost);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (TangoCardSdkException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Tango Card SDK Failure ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Unexpected Error ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Purchase Card ====\n\n\n");
        }
    }
}
