TangoCard .Net/C-Sharp SDK
=================

# Overview #
The Tango Card .NET 4.0/C# SDK is a wrapper around the Tango Card Service API environments. As such, it has two primary types of objects, Requests and Responses; which are handled by a wrapper class `TangoCard.Sdk.TangoCardServiceApi`.

The wrapper class `TangoCard.Sdk.TangoCardServiceApi` currently handles the following static methods:
<dl>
	<dt>bool GetAvailableBalance()</dt>
	<dd>- Gather the currently available balance for provided user within their www.tangocard.com account.</dd>

	<dt>bool PurchaseCard()</dt>
	<dd>- Purchase a gift card using funds from user's www.tangocard.com account.</dd>
</dl>

![Tango Card Service Api](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocardserviceapi.png "Tango Card Service Api")

# Requirements #
[Visual Studio 2010](http://www.microsoft.com/visualstudio/en-us/products/2010-editions)  
[Newtonsoft.JSON](http://james.newtonking.com/projects/json-net.aspx)  

# Tango Card Service Requests #

The Tango Card SDK, every Request has a corresponding success-case Response object.

## Tango Card Service API ##

Available are two endpoints that provide the Tango Card Service API, as defined by `enum TangoCard.Sdk.Service.TangoCardServiceApiEnum` :
* `INTEGRATION` - Expected to be used for development and testing purposes.
* `PRODUCTION` - Performs actual card purchase requests.

Requests are secure HTTP POST using SSL.

## Get Available Balance ##

![Tango Card Service API - GetAvailableBalance()](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocardserviceapi_getavailablebalance.png "Tango Card Service API - GetAvailableBalance()")

This request is defined by static method call `TangoCard.Sdk.TangoCardServiceApi.GetAvailableBalance()`:

```C#
	TangoCardServiceApiEnum enumTangoCardServiceApi = TangoCardServiceApiEnum.INTEGRATION;
	string username = "burt@example.com";
	string password = "password";
			
	GetAvailableBalanceResponse response = null;
	if (TangoCardServiceApi.GetAvailableBalance(
			enumTangoCardServiceApi: enumTangoCardServiceApi,
			username: username,
			password: password,
			response: out response
			) 
			&& (null != response)
	) {
	{
		double dollarsAvailableBalance = response.AvailableBalance / 100;
		Console.WriteLine("\n- Available Balance: {0:C}\n", dollarsAvailableBalance);
	}	
```

The `out` parameter `responseGetAvailableBalance` will now be (assuming success) a `TangoCard.Sdk.Response.Success.GetAvailableBalanceResponse` type object.

### static method `TangoCard.Sdk.TangoCardServiceApi.GetAvailableBalance()` ###

#### Parameters ####
<dl>
  <dt>TangoCardServiceApiEnum enumTangoCardServiceApi</dt>
  <dd>- INTEGRATION and PRODUCTION</dd>
  
  <dt>string username</dt>
  <dd>- User email address, and the SDK Integration test username is defined in TangoCard.Sdk.Examples' configuration file *app.config* within *app_username*</dd>

  <dt>string password</dt>
  <dd>- User password, and the SDK Integration test password is defined in TangoCard.Sdk.Examples' configuration file *app.config* within *app_password*</dd>

  <dt>TangoCard.Sdk.Response.Success.GetAvailableBalanceResponse response</dt>
  <dd>- This `out` paramter will provide a valid success response object if this method returns true upon success.</dd>
</dl>

### `TangoCard.Sdk.Response.Success.GetAvailableBalanceResponse` Properties ###

<dl>
  <dt>int getAvailableBalance</dt>
  <dd>- Returns available balance of username's account in cents: 100 is $1.00 dollar.</dd>
</dl>

## Purchase Card ##

![Tango Card Service API - PurchaseCard()](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocardserviceapi_purchasecard.png "Tango Card Service API - PurchaseCard()")

This request is defined by static method call `TangoCard.Sdk.TangoCardServiceApi.PurchaseCard()`:

```C#
	TangoCardServiceApiEnum enumTangoCardServiceApi = TangoCardServiceApiEnum.INTEGRATION;
	string username = "burt@example.com";
	string password = "password";
	string cardSku = "tango-card";
	int cardValueTangoCardCents = 100; // $1.00
	
	PurchaseCardResponse response = null;
	if (TangoCardServiceApi.PurchaseCard(
			enumTangoCardServiceApi: enumTangoCardServiceApi,
			username: username,
			password: password,
			cardSku: cardSku,
			cardValue: cardValueTangoCardCents,
			tcSend: true,
			giftFrom: "Bill Example",
			giftMessage: "Happy Birthday",
			recipientEmail: "sally@example.com",
			recipientName: "Sally Example",
			response: out response )  
		&& (null != response)
	) {
		Console.WriteLine("\n- Purchased Card (Delivery): {{ \nCard Number: {0}, \nCard Pin: {1}, \nCard Token {2}, \nOrder Number: {3} \n}}\n",
			response.CardNumber,
			response.CardPin,
			response.CardToken,
			response.ReferenceOrderId
			);
	}
```

Its response `$requestPurchaseCardRequest_Delivery` will now be (assuming success) a `TangoCard.Sdk.Response.Success.PurchaseCardResponse` type object.

### `TangoCard.Sdk.TangoCardServiceApi.PurchaseCard()` Method ###

#### Parameters ###

<dl>
  <dt>TangoCardServiceApiEnum enumTangoCardServiceApi</dt>
  <dd>- INTEGRATION or PRODUCTION</dd>

  <dt>string username</dt>
  <dd>- User email address, and a SDK Integration test username is defined in TangoCard.Sdk.Examples' configuration file *app.config* within *app_username*</dd>

  <dt>string password</dt>
  <dd>- User password, and a SDK Integration test password is defined in TangoCard.Sdk.Examples' configuration file *app.config* within *app_password*</dd>

  <dt>string cardSku</dt>
  <dd>- Card brand request, and the Tango Card brand's card sku *tango-card* is defined in TangoCard.Sdk.Examples' configuration file *app.config* within *app_card_sku*</dd>

  <dt>int cardValue</dt>
  <dd>- Card value in cents; a value of 100 (cent) is $1.00 dollar card. Minimum value is 1 (cent).</dd>

  <dt>boolean tcSend</dt>
  <dd>- Tango Card Service delivers by Email requested card. Set to true for email delivery, and false for no delivery.</dd>

  <dt>string recipientName</dt>
  <dd>- Full name of recipient receiving gift card. Set this value with either a string (length minumum 1 character to maximum of 255 characters) if `tcSend` is true, or null if parameter `tcSend` is false.</dd>

  <dt>string recipientEmail</dt>
  <dd>- Valid email address of recipient receiving gift card. Set this value with either a string (length minumum 1 character to maximum of 255 characters) if `tcSend` is true, or null if parameter `tcSend` is false.</dd>

  <dt>string giftMessage</dt>
  <dd>- [Optional] Gift message to be applied to gift card's email. Set this value with either a string (length minumum 1 character to maximum of 255 characters) or null if `tcSend` is true, or null if parameter `tcSend` is false.</dd>

  <dt>string giftFrom</dt>
  <dd>- Full name of giver of gift card. Set this value with either a string (length minumum 1 character to maximum of 255 characters) if `tcSend` is true, or null if parameter `tcSend` is false.</dd>

  <dt>TangoCard.Sdk.Response.Success.PurchaseCardResponse response</dt>
  <dd>- This out paramter will provide a valid success response object if this method returns true upon success.</dd>
</dl>

### `TangoCard.Sdk.Response.Success.PurchaseCardResponse` Properties ###

<dl>
  <dt>String getReferenceOrderId</dt>
  <dd>- Confirmation number of purchase.</dd>
  
  <dt>String getCardToken</dt>
  <dd>- Card reference to the aforementioned purchase.</dd>
  
  <dt>String getCardNumber</dt>
  <dd>- Card number provided to the recipient to be used at redemption upon the www.tangocard.com site.</dd>
  
  <dt>String getCardPin</dt>
  <dd>- Card pin provided to the recipient used to validate provided Card number a redemption upon the www.tangocard.com site.</dd>
</dl>

# Tango Card Error Handling #

The Tango Card Service API SDK handles its errors by throwing the following exceptions:

* Custom `TangoCard.Sdk.Service.TangoCardServiceException` is thrown when the `Tango Card Service API` return a `Failure Response` for a given `Request`.
* Custom `TangoCard.Sdk.Common.TangoCardSdkException` is thrown when the Tango Card SDK has detected an error within its code, regardless of any given Request.
* Standard `java.lang.IllegalArgumentException` is thrown due to parameter entry errors.

![Tango Card SDK Exceptions](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_exceptions.png "Tango Card SDK Exceptions")

## Service Failure Responses ##

A service will return the following failure responses as enumerated by `TangoCard.Sdk.Response.ServiceResponseEnum`:

<table>
	<tr><th>Failure</th><th>Failure Reponse Type</th><th>Failure Response Object</th></tr>
	<tr><td>Insufficient Funds</td><td>INS_FUNDS</td><td>`TangoCard.Sdk.Response.Failure.InsufficientFundsResponse`</td></tr>
	<tr><td>Insufficient Inventory</td><td>INS_INV</td><td>`TangoCard.Sdk.Response.Failure.InsufficientInventoryResponse`</td></tr> 
	<tr><td>Invalid Credentials</td><td>INV_CREDENTIAL</td><td>`TangoCard.Sdk.Response.Failure.InvalidCredentialsResponse`</td></tr> 
	<tr><td>Invalid Input</td><td>INV_INPUT</td><td>`TangoCard.Sdk.Response.Failure.InvalidInputResponse`</td></tr>
	<tr><td>System Failure</td><td>SYS_ERROR</td><td>`TangoCard.Sdk.Response.Failure.SystemFailureResponse`</td></tr>
</table>

Each of the aforementioned `Failure Responses` contains details as to the reason that the `Tango Card Service API` did not perform provided `Request`.

![Tango Card SDK Service Response Failures](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_service_failure_response.png "Tango Card SDK Service Response Failures")

The details of these service failure responses are embedded and thrown within `TangoCard.Sdk.Service.TangoCardServiceException`

### Expected Failure Responses for Specific Requests ###

Each Request will have the following possible Failure Responses as a property value within `TangoCard.Sdk.Service.TangoCardServiceException.getResponse()`:

<table>
	<tr><th>Request</th><th>Possible Failure Responses</th></tr>
	<tr>
		<td>`GetAvailableBalanceRequest`</td>
		<td>
			<table>
				<tr><th>Failure Reponse Type</th><th>Failure Response</th></tr>
				<tr><td>INV_CREDENTIAL</td><td>`InvalidCredentialsResponse`</td></tr> 
				<tr><td>SYS_ERROR</td><td>`SystemFailureResponse`</td></tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>`PurchaseCardRequest`</td>
		<td>
			<table>
				<tr><th>Failure Reponse Type</th><th>Failure Response</th></tr>
				<tr><td>INS_FUNDS</td><td>`InsufficientFundsResponse`</td></tr>
				<tr><td>INS_INV</td><td>`InsufficientInventoryResponse`</td></tr> 
				<tr><td>INV_CREDENTIAL</td><td>`InvalidCredentialsResponse`</td></tr> 
				<tr><td>INV_INPUT</td><td>`InvalidInputResponse`</td></tr>
				<tr><td>SYS_ERROR</td><td>`SystemFailureResponse`</td></tr>
			</table>
		</td>
	</tr>
</table>

## SDK Error Responses ##

This SDK throws it own custom exception `TangoCard.Sdk.Common.TangoCardSdkException` when detecting errors that pertain to itself.

![Tango Card SDK Error Detection](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_error_detected.png "Tango Card SDK Error Detection")

## Handling Errors ##

Wrap every Tango Card request call within a try/catch block, followed by first catching `TangoCard.Sdk.Service.TangoCardServiceException`, then by `TangoCard.Sdk.Common.TangoCardSdkException`, and finally by standard `Exception`.

```C#
	try
	{
		string username = "burt@example.com";
		string password = "password";
		TangoCardServiceApiEnum enumTangoCardServiceApi = TangoCardServiceApiEnum.INTEGRATION;
				
		GetAvailableBalanceResponse response = null;
		if (TangoCardServiceApi.GetAvailableBalance(
				enumTangoCardServiceApi: enumTangoCardServiceApi,
				username: username,
				password: password,
				response: out response
				) 
				&& (null != response)
		) {
            // Do Stuff ... //
		}
	}
	catch (TangoCardServiceException ex)
	{
		Console.WriteLine("=== Tango Card Service Failure ===");
		Console.WriteLine("Failure response type: {0}", ex.ResponseType.ToString());
		Console.WriteLine("Failure response:      {0}", ex.Message);
	}
	catch (TangoCardSdkException ex)
	{
		Console.WriteLine("=== Tango Card SDK Failure ===");
		Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
	}
	catch (Exception ex)
	{
		Console.WriteLine("=== Unexpected Error ===");
		Console.WriteLine("{0} :: {1}", ex.GetType().ToString(), ex.Message);
	}
```

# .NET 4.0 SDK Development Environment #
This .NET 4.0 SDK was built using:

* Visual Studio 2010 Ultimate
* .NET 4.0
* NuGET Newtonsoft.JSON

# SDK Structure #
There are four directories in the SDK: `doc`, `TangoCard.Sdk.Examples`, `TangoCard.Sdk.Unittests`, `TangoCard.Sdk`, and key `configuration files`.



## configuration files ##

There a several configuration files that are referenced by either the provide application examples, unittests, and SDK itself.

<dl>
	<dt>TangoCard.Sdk.Examples\app.config</dt>
	<dd>- Application configuration file for `TangoCard.Sdk.Examples`</dd>
	
	<dt>TangoCard.Sdk.Unittests\app.config</dt>
	<dd>- Application configuration file for `TangoCard.Sdk.Unittests`</dd>
	
	<dt>TangoCard.Sdk\TangoCard_DotNet_SDK.dll.config</dt>
	<dd>- SDK configuration file referenced by `TangoCard.Sdk\Common\SdkConfig.cs`. **DO NOT MODIFY**</dd>
</dl>

## doc ##
The docs sub-directory maintains the up-to-date documentation for the classes (and functions) that are included in the SDK.

## TangoCard.Sdk.Examples ##
The examples sub-directory contains full "start to finish" examples of all of the supported methods. This includes catching all of the possible failure modes, etc. 

### TangoCard_Store_Example.cs ###

This is a complete example of requesting available balance and purchasing Tango Cards.

1. Request latest available balance
2. Purchase $1.00 Tango Card for Email Delivery
3. Purchase $1.00 Tango Card without Email Delivery
4. Request updated available balance

### TangoCard_Failures_Example.cs ###

Example of how the SDK handles various failure responses, such as:
* Insufficient Funds
* Invalid Credentials
* Invalid Input

### Command Line ###

```Text
	> TangoCard.Sdk.Examples\bin\Release\TangoCard.Sdk.Examples.exe

	===============================
	= Tango Card .NET SDK Example =
	===============================

	== Using app.config Credentials ====

	======== Get Available Balance ========
	- Available Balance: $8,755,447.00
	===== End Get Available Balance ====

	===== Purchase Card (No Delivery) =====
	- Purchased Card (No Delivery): {
		Card Number: 7001-3040-0131-6599-211,
		Card Pin: 801756,
		Card Token 5017684fd1ffa1.17620500,
		Order Number: 112-07212544-31
		}
	===== End Purchase Card (No Delivery) ====

	======== Purchase Card (Delivery) ========
	- Purchased Card (Delivery): {
		Card Number: 7001-3040-0132-4383-910,
		Card Pin: 817164,
		Card Token 5017685081d0c4.28984626,
		Order Number: 112-07212545-31
		}
	======== End Purchase Card (Delivery) ========

	======== Get Updated Available Balance ========
	- Updated Available Balance: $8,755,445.00
	===== End Get Updated Available Balance ====

	===============================
	=   The End                   =
	===============================

	===============================
	= Tango Card .NET SDK Example =
	=   with Failures             =
	===============================

	== Using app.config Credentials ====

	======== Get Available Balance ========
	=== Tango Card Service Failure ===
	Failure response type: INV_CREDENTIAL
	Failure response:      Provided user credentials are not valid.
	===== End Get Available Balance ====


	== Using app.config Credentials ====
	======== Purchase Card ========
	=== Tango Card Service Failure ===
	Failure response type: INS_FUNDS
	Failure response:      Available Balance: 0, Order Cost: 100
	AvailableBalance:      0
	OrderCost:             100
	===== End Purchase Card ====

	======== Purchase Card ========
	=== Tango Card Service Failure ===
	Failure response type: INV_INPUT
	Failure response:      cardSku: SKU does not appear to be valid.,
	Invalid:      cardSku: SKU does not appear to be valid.,
	===== End Purchase Card ====

	======== Purchase Card ========
	=== Tango Card Service Failure ===
	Failure response type: INS_FUNDS
	Failure response:      Available Balance: 875544519, Order Cost: 1000000000
	AvailableBalance:      875544519
	OrderCost:             1000000000
	===== End Purchase Card ====

	===============================
	=   The End                   =
	===============================

	Press Any Key to Close this program.
```

## TangoCard.Sdk.Unittests ##

The SDK's unittests have been written to use [Visual Studio 2010][UnitTest Project].

* `UnitTest_GetAvailableBalance`
* `UnitTest_PurchaseCard`

#### UnitTest Command Line Run ####

To run these unit tests requires installation of Visual Studio 2010 Professional.

Open a Visual Studio 2010 command prompt. 

To do this, click Start, point to All Programs, point to Microsoft Visual Studio 2010, point to Visual Studio Tools, and then click Visual Studio 2010 Command Prompt.

```Text
	MSTest /testcontainer:TangoCard.Sdk.Unittests\bin\Release\TangoCard.Sdk.Unittests.dll
	Microsoft (R) Test Execution Command Line Tool Version 10.0.30319.1
	Copyright (c) Microsoft Corporation. All rights reserved.

	Loading TangoCard.Sdk.Unittests\bin\Release\TangoCard.Sdk.Unittests.dll...
	Starting execution...

	Results               Top Level Tests
	-------               ---------------
	Passed                TangoCard.Sdk.Unittests.UnitTest_GetAvailableBalance.Test_GetAvailableBalance_Api
	Passed                TangoCard.Sdk.Unittests.UnitTest_GetAvailableBalance.Test_GetAvailableBalance_InsufficientFunds
	Passed                TangoCard.Sdk.Unittests.UnitTest_GetAvailableBalance.Test_GetAvailableBalance_InvalidCredentials
	Passed                TangoCard.Sdk.Unittests.UnitTest_GetAvailableBalance.Test_GetAvailableBalance_Request
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_InsufficientFunds
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_InsufficientFunds_10000000
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_InvalidCredentials
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_InvalidInput_Sku
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_with_Delivery
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_with_NoDelivery
	Passed                TangoCard.Sdk.Unittests.UnitTest_PurchaseCard.Test_PurchaseCard_with_NoDelivery_Api
	11/11 test(s) Passed

	Summary
	-------
	Test Run Completed.
	  Passed  11
	  ----------
	  Total   11
```


## lib ##
This is the heart of the SDK... the src sub-directory is where all of the code lies. 

# License #
The Tango Card .NET 4.0/C# SDK is free to use, given some restrictions. Please see the LICENSE file for details.

# Integration #
When you're ready to go live, email [sales@tangocard.com](mailto:sales@tangocard.com). We'll get you set up with a contract and everything else you need, including linking your account so that transactions served via your integration will draw down on your Tango Card account. 
