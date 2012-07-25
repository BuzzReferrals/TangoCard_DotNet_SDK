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
using TangoCard.Sdk.Response.Success;
using TangoCard.Sdk.Service;
using System.Net;

namespace TangoCard.Sdk.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.TCStore_Using_AppConfig();

            Console.WriteLine("Press Any Key to Close this program.");

            Console.ReadLine();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tango Card store using application configuration. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void TCStore_Using_AppConfig()
        {
            // Test Available Balance
            Console.WriteLine("== Using app.config Credentials ====\n");

            string app_production_mode = ConfigurationManager.AppSettings["app_production_mode"];
            bool is_production_mode = false;
            Boolean.TryParse(app_production_mode, out is_production_mode);

            string app_username             = ConfigurationManager.AppSettings["app_username"];
            string app_password             = ConfigurationManager.AppSettings["app_password"];
            string app_company_identifier   = ConfigurationManager.AppSettings["app_company_identifier"];

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
                if (request.execute(ref response) && (null != response))
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
                    companyIdentifier: app_company_identifier,
                    cardSku: "tango-card",
                    cardValue: 100,    // $1.00 value
                    tcSend: false
                );
                PurchaseCardResponse response = null;
                if (request.execute(ref response) && (null != response))
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
                    companyIdentifier: app_company_identifier,
                    cardSku: "tango-card",
                    cardValue: 100,    // $1.00 value
                    tcSend: true,
                    giftFrom: "From",
                    giftMessage: "Message",
                    recipientEmail: "test00tangocard@gmail.com",
                    recipientName: "Test Tangocard"
                );

                PurchaseCardResponse response = null;
                if (request.execute(ref response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n- Purchased Card (Delivery): {{ \nCard Token {0}, \nOrder Number: {1} \n}}\n",
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
                if (request.execute(ref response) && (null != response))
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
        }
    }
}
