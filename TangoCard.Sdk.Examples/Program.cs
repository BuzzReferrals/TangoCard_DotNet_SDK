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
using System.Configuration;

using System.Text;

using TangoCard.Sdk.Request;

namespace TangoCard.Sdk.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.TCStore_Using_Default_SDK_Config();
            Program.TCStore_Using_AppConfig();

            Console.WriteLine("Press Any Key to Close this program.");

            Console.ReadLine();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tango Card store using default sdk configuration. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void TCStore_Using_Default_SDK_Config()
        {
            // Test Available Balance
            Console.WriteLine("== Using default TangoCard.Sdk.dll.config Credentials ====\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Get Available Balance ========");

                var request = new GetAvailableBalanceRequest();
                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                double dollarsAvailableBalance = result.AvailableBalance / 100;
                Console.WriteLine("\n- Available Balance: {0:C}\n", dollarsAvailableBalance);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Getting Available Balance ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Available Balance ====\n\n\n");


            // Test Purchase Card no delivery
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("===== Purchase Card (No Delivery) =====");

                var request = new PurchaseCardRequest()
                {
                    CardSku = "tango-card",
                    CardValue = 100,    // $1.00 value
                    TcSend = false
                };
                var result = request.execute();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n- Purchased Card (No Delivery): {{ Card Number: {0}, Card Pin: {1}, Card Token {2}, Order Number: {3} }}\n", result.CardNumber, result.CardPin, result.CardToken, result.ReferenceOrderId);
                Console.ForegroundColor = ConsoleColor.Cyan;
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

                var request = new PurchaseCardRequest()
                {
                    CardSku = "tango-card",
                    CardValue = 100,    // $1.00 value
                    GiftFrom = "From",
                    GiftMessage = "Message",
                    RecipientEmail = "test00tangocard@gmail.com",
                    RecipientName = "Test Tangocard",
                    TcSend = true
                };

                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n- Purchased Card (Delivery): {{ Card Token {0}, Order Number: {1} }}\n", result.CardToken, result.ReferenceOrderId);
                Console.ForegroundColor = ConsoleColor.Cyan;
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

                var request = new GetAvailableBalanceRequest();
                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                double dollarsAvailableBalance = result.AvailableBalance / 100;
                Console.WriteLine("\n- Updated Available Balance: {0:C}\n", dollarsAvailableBalance);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Getting Updated Available Balance ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Updated Available Balance ====\n\n\n");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tango Card store using application configuration. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void TCStore_Using_AppConfig()
        {
            // Test Available Balance
            Console.WriteLine("== Using app.config Credentials ====\n");

            string app_username = ConfigurationManager.AppSettings["app_username"];
            string app_password = ConfigurationManager.AppSettings["app_password"];

            string app_production_mode = ConfigurationManager.AppSettings["app_production_mode"];
            bool is_production_mode = false;
            Boolean.TryParse(app_production_mode, out is_production_mode);

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Get Available Balance ========");

                var request = new GetAvailableBalanceRequest
                {
                    Username = app_username,
                    Password = app_password,
                    IsProductionMode = is_production_mode
                };
                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                double dollarsAvailableBalance = result.AvailableBalance / 100;
                Console.WriteLine("\n- Available Balance: {0:C}\n", dollarsAvailableBalance);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Getting Available Balance ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Available Balance ====\n\n\n");


            // Test Purchase Card no delivery
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("===== Purchase Card (No Delivery) =====");

                var request = new PurchaseCardRequest()
                {
                    Username = app_username,
                    Password = app_password,
                    IsProductionMode = is_production_mode,
                    CardSku = "tango-card",
                    CardValue = 100,    // $1.00 value
                    TcSend = false
                };
                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n- Purchased Card (No Delivery): {{ Card Number: {0}, Card Pin: {1}, Card Token {2}, Order Number: {3} }}\n", result.CardNumber, result.CardPin, result.CardToken, result.ReferenceOrderId);
                Console.ForegroundColor = ConsoleColor.Cyan;
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

                var request = new PurchaseCardRequest()
                {
                    Username = app_username,
                    Password = app_password,
                    IsProductionMode = is_production_mode,
                    CardSku = "tango-card",
                    CardValue = 100,    // $1.00 value
                    GiftFrom = "From",
                    GiftMessage = "Message",
                    RecipientEmail = "test00tangocard@gmail.com",
                    RecipientName = "Test Tangocard",
                    TcSend = true
                };

                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n- Purchased Card (Delivery): {{ Card Token {0}, Order Number: {1} }}\n", result.CardToken, result.ReferenceOrderId);
                Console.ForegroundColor = ConsoleColor.Cyan;
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
                {
                    Username = app_username,
                    Password = app_password,
                    IsProductionMode = is_production_mode
                };
                var result = request.execute();

                Console.ForegroundColor = ConsoleColor.Green;
                double dollarsAvailableBalance = result.AvailableBalance / 100;
                Console.WriteLine("\n- Updated Available Balance: {0:C}\n", dollarsAvailableBalance);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Error Getting Updated Available Balance ===");
                Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.WriteLine("===== End Get Updated Available Balance ====\n\n\n");
        }
    }
}
