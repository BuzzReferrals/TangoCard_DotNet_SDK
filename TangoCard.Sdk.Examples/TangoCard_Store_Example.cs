﻿//  
//  TangoCard_Store_Example.cs
//  TangoCard_DotNet_SDK
//  
//  Example code using Tango Card SDK to get available balance and purchase card.
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
// 

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using TangoCard.Sdk.Common;
using TangoCard.Sdk.Request;
using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Service;


namespace TangoCard.Sdk.Examples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Tango card store example. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TangoCard_Store_Example
    {
        static public void Execute()
        {
            Console.WriteLine("\n===============================\n");
            Console.WriteLine(  "= Tango Card .NET SDK Example =\n");
            Console.WriteLine(  "===============================\n");

            Console.WriteLine("== Using app.config Credentials ====\n");

            string app_production_mode = ConfigurationManager.AppSettings["app_production_mode"];
            bool is_production_mode = false;
            Boolean.TryParse(app_production_mode, out is_production_mode);

            string app_username = ConfigurationManager.AppSettings["app_username"];
            string app_password = ConfigurationManager.AppSettings["app_password"];

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Get Available Balance ========");

                var request = new GetAvailableBalanceRequest
                (
                    isProductionMode: is_production_mode,
                    username: app_username,
                    password: app_password
                );
                GetAvailableBalanceResponse response = null;
                if (request.Execute(ref response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    double dollarsAvailableBalance = response.AvailableBalance / 100;
                    Console.WriteLine("\n- Available Balance: {0:C}\n", dollarsAvailableBalance);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Failed getting Available Balance ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Getting Available Balance ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Available Balance ====\n\n\n");

            int cardValue = 100; // $1.00 

            // Test Purchase Card no delivery
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("===== Purchase Card (No Delivery) =====");

                var request = new PurchaseCardRequest
                (
                    isProductionMode: is_production_mode,
                    username: app_username,
                    password: app_password,
                    cardSku: "tango-card",
                    cardValue: cardValue,    // $1.00 value
                    tcSend: false
                );
                PurchaseCardResponse response = null;
                if (request.Execute(ref response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n- Purchased Card (No Delivery): {{ \nCard Number: {0}, \nCard Pin: {1}, \nCard Token {2}, \nOrder Number: {3} \n}}\n",
                        response.CardNumber,
                        response.CardPin,
                        response.CardToken,
                        response.ReferenceOrderId
                        );
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Failed Purchasing Card (No Delivery) ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Purchasing Card (No Delivery) ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Purchase Card (No Delivery) ====\n\n\n");

            // Test Purchase Card no delivery
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Purchase Card (Delivery) ========");

                var request = new PurchaseCardRequest
                (
                    isProductionMode: is_production_mode,
                    username: app_username,
                    password: app_password,
                    cardSku: "tango-card",
                    cardValue: cardValue,    // $1.00 value
                    tcSend: true,
                    giftFrom: "Bill Test Giver",
                    giftMessage: "Happy Birthday",
                    recipientEmail: "sue_test_recipient@test.com",
                    recipientName: "Sue Test Recipient"
                );

                PurchaseCardResponse response = null;
                if (request.Execute(ref response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n- Purchased Card (Delivery): {{ \nCard Number: {0}, \nCard Pin: {1}, \nCard Token {2}, \nOrder Number: {3} \n}}\n",
                        response.CardNumber,
                        response.CardPin,
                        response.CardToken,
                        response.ReferenceOrderId
                        );
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Failed Purchasing Card (Delivery) ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Purchasing Card (Delivery) ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("======== End Purchase Card (Delivery) ========\n\n\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Get Updated Available Balance ========");

                var request = new GetAvailableBalanceRequest
                (
                    isProductionMode: is_production_mode,
                    username: app_username,
                    password: app_password
                );
                GetAvailableBalanceResponse response = null;
                if (request.Execute(ref response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    double dollarsAvailableBalance = response.AvailableBalance / 100;
                    Console.WriteLine("\n- Updated Available Balance: {0:C}\n", dollarsAvailableBalance);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=== Failed getting Available Balance ===");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Getting Updated Available Balance ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Updated Available Balance ====\n\n\n");

            Console.WriteLine("\n===============================\n");
            Console.WriteLine(  "=   The End                   =\n");
            Console.WriteLine(  "===============================\n");
        }
    }
}