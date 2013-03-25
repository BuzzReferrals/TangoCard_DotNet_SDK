//
//  TangoCard_Store_Example.cs
//  TangoCard_DotNet_SDK
//
//  Example code using Tango Card SDK to get available balance and purchase card.
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
using System.Configuration;

using TangoCard.Sdk.Response.Success.Version2;
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
            Console.WriteLine("\n===============================");
            Console.WriteLine("= Tango Card .NET SDK Example =");
            Console.WriteLine("===============================\n");

            Console.WriteLine(String.Format("SDK Version: {0}\n", TangoCardServiceApi.GetVersion()));

            Console.WriteLine("== Using app.config Credentials ====\n");

            string app_tc_sdk_environment = ConfigurationManager.AppSettings["app_tc_sdk_environment"];
            TangoCardServiceApiEnum enumTangoCardServiceApi = (TangoCardServiceApiEnum)Enum.Parse(typeof(TangoCardServiceApiEnum), app_tc_sdk_environment);

            string app_username = ConfigurationManager.AppSettings["app_username"];
            string app_password = ConfigurationManager.AppSettings["app_password"];
            string app_card_sku = ConfigurationManager.AppSettings["app_card_sku"];
            string app_card_value = ConfigurationManager.AppSettings["app_card_value"];
            string app_recipient_email = ConfigurationManager.AppSettings["app_recipient_email"];

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("======== Get Available Balance ========");

                Version2_GetAvailableBalance_Response response = null;
                if (TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        response: out response)
                        && (null != response)
                )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    double dollarsAvailableBalance = response.AvailableBalance / 100;
                    Console.WriteLine("\n'{0}': Available Balance: {1}\n", app_username, response.AvailableBalance);
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

            int cardValueTangoCardCents = 0;
            int.TryParse(app_card_value, out cardValueTangoCardCents);

            // Test Purchase Card no delivery
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.WriteLine("===== Purchase Card (No Delivery) =====");

                Version2_PurchaseCard_Response response = null;
                if (TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        cardSku: app_card_sku,
                        cardValue: cardValueTangoCardCents,
                        tcSend: false,
                        recipientName: null,
                        recipientEmail: null,
                        giftFrom: null,
                        giftMessage: null,
                        companyIdentifier: null,
                        response: out response
                    )
                    && (null != response)
                )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n- Purchased Card (No Delivery): {{ " +
                        "\n\tReference Order Id: '{0}' " +
                        ", \n\tCard Token '{1}' " +
                        ", \n\tCard Number: '{2}' " +
                        ", \n\tCard Pin: '{3}' " +
                        ", \n\tClaim Url: '{4}' " +
                        ", \n\tChallenge Key: '{5}'  " + +
                        ", \n\tEvent Number: '{6}' " +
                        "  \n}}\n",
                        response.ReferenceOrderId,
                        response.CardToken,
                        response.CardNumber,
                        response.CardPin,
                        response.ClaimUrl,
                        response.ChallengeKey,
                        response.EventNumber
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

                Version2_PurchaseCard_Response response = null;
                if (TangoCardServiceApi.PurchaseCard(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        cardSku: app_card_sku,
                        cardValue: cardValueTangoCardCents,
                        tcSend: true,
                        giftFrom: "Bill Support",
                        giftMessage: "Hello from Tango Card C#/.NET SDK:\nTango Card\nPhone: 1-877-55-TANGO\n601 Union Street, Suite 4200\nSeattle, WA 98101",
                        recipientEmail: app_recipient_email,
                        recipientName: "Sally Customer",
                        companyIdentifier: null,
                        response: out response
                    )
                    && (null != response)
                )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n- Purchased Card (Delivery): {{ " +
                            "\n\tRecipient Email: '{0}' " +
                            ", \n\tReference Order Id: '{1}' " +
                            ", \n\tCard Token '{2}' " +
                            ", \n\tCard Number: '{3}' " +
                            ", \n\tCard Pin: '{4}' " +
                            ", \n\tClaim Url: '{5}' " +
                            ", \n\tChallenge Key: '{6}' " +
                            ", \n\tEvent Number: '{7}' " +
                            "  \n}}\n",
                        app_recipient_email,
                        response.ReferenceOrderId,
                        response.CardToken,
                        response.CardNumber,
                        response.CardPin,
                        response.ClaimUrl,
                        response.ChallengeKey,
                        response.EventNumber
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

                Version2_GetAvailableBalance_Response response = null;
                if (TangoCardServiceApi.GetAvailableBalance(
                        enumTangoCardServiceApi: enumTangoCardServiceApi,
                        username: app_username,
                        password: app_password,
                        response: out response) && (null != response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    double dollarsAvailableBalance = response.AvailableBalance / 100;
                    Console.WriteLine("\n'{0}': Updated Available Balance: {1}\n", app_username, response.AvailableBalance);
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

            Console.WriteLine("\n===============================");
            Console.WriteLine("=   The End                   =");
            Console.WriteLine("===============================");
        }
    }
}