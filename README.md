TangoCard .Net/C-Sharp SDK
=================

# Overview #
The Tango Card .NET 4.0/C-Sharp SDK is a wrapper around the Tango Card Extend API. As such, it has two primary types of objects: Requests and Responses.

# Tango Card Service Requests #

The Tango Card SDK, every Request has a corresponding success-case Response object. 

![Tango Card SDK Requests](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_service_success_response.png "Tango Card SDK Requests")

## Get Available Balance ##

This request is defined by `class TangoCard\Sdk\Request\GetAvailableBalanceRequest`

	// set up the request
	var request = new GetAvailableBalanceRequest
	(
		isProductionMode: is_production_mode,
		username: app_username,
		password: app_password
	);
	
	// make the request
	GetAvailableBalanceResponse response = null;
	if (request.Execute(ref response) && (null != response))
	{
		double dollarsAvailableBalance = response.AvailableBalance / 100;
		Console.WriteLine("\n- Available Balance: {0:C}\n", dollarsAvailableBalance);
	}	

Its response `$responseAvailableBalance` will now be (assuming success) a `TangoCard\Sdk\Response\Success\GetAvailableBalanceResponse` type object.

## Purchase Tango Card ##

This request is defined by `class TangoCard\Sdk\Request\PurchaseCardRequest`

    // set up the request
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

	// make the request
	PurchaseCardResponse response = null;
	if (request.Execute(ref response) && (null != response))
	{
		Console.WriteLine("\n- Purchased Card (Delivery): {{ \nCard Number: {0}, \nCard Pin: {1}, \nCard Token {2}, \nOrder Number: {3} \n}}\n",
			response.CardNumber,
			response.CardPin,
			response.CardToken,
			response.ReferenceOrderId
			);
	}
	
Its response `$requestPurchaseCardRequest_Delivery` will now be (assuming success) a `TangoCard\Sdk\Response\Success\PurchaseCardResponse` type object.

# Tango Card Error Handling #

There are also failure-case response objects. Each Request will explain (in the documentation) what type of possible failure-case response objects can be expected.

![Tango Card SDK Exceptions](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_exceptions.png "Tango Card SDK Exceptions")

## Service Failure Responses ##

A service will return the following failure responses as enumerated by `TangoCard\Sdk\Response\ServiceResponseEnum`:

<table>
	<tr><td>Insufficient Funds</td><td>INS_FUNDS</td><td>`TangoCard\Sdk\Response\Failure\InsufficientFundsResponse`</td></tr>
	<tr><td>Insufficient Inventory</td><td>INS_INV</td><td>`TangoCard\Sdk\Response\Failure\InsufficientInventoryResponse`</td></tr> 
	<tr><td>Invalid Credentials</td><td>INV_CREDENTIAL</td><td>`TangoCard\Sdk\Response\Failure\InvalidCredentialsResponse`</td></tr> 
	<tr><td>Invalid Input</td><td>INV_INPUT</td><td>`TangoCard\Sdk\Response\Failure\InvalidInputResponse`</td></tr>
	<tr><td>System Failure</td><td>SYS_ERROR</td><td>`TangoCard\Sdk\Response\Failure\SystemFailureResponse`</td></tr>
</table>

![Tango Card SDK Service Response Failures](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_service_failure_response.png "Tango Card SDK Service Response Failures")

The details of these service failure responses are embedded and thrown within `TangoCard\Sdk\ServiceTangoCardServiceException`

## SDK Error Responses ##

Along with standard `InvalidArgumentException` for catching parameter entry errors, the SDK throws it own exception when detecting errors that pertain to itself `TangoCard\Sdk\Common\TangoCardSdkException`.

![Tango Card SDK Error Detection](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/dev/doc/images/tangocard_sdk_sdk_error_detected.png "Tango Card SDK Error Detection")

## Handling Errors ##

Wrap every Tango Card request call within a try/catch block, followed by first catching `TangoCard\Sdk\Service\TangoCardServiceException`, then by `\TangoCard\Sdk\Common\TangoCardSdkException`, and finally by standard `Exception`.

	try
	{
		// set up the request
		var request = new GetAvailableBalanceRequest
		(
			isProductionMode: is_production_mode,
			username: username,
			password: password
		);
		
		// make the request
		GetAvailableBalanceResponse response = null;
		if (request.Execute(ref response) && (null != response))
		{
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

# SDK Structure #
There are four directories in the SDK: `doc`, `TangoCard.Sdk.Examples`, `TangoCard.Sdk.Unittests`, and `TangoCard.Sdk`.

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

## TangoCard.Sdk.Unittests ##

The SDK's unittests have been written to use [Visual Studio 2010][UnitTest Project].

* `UnitTest_GetAvailableBalance`
* `UnitTest_PurchaseCard`


## lib ##
This is the heart of the SDK... the src sub-directory is where all of the code lies. 

# Requirements #
[Visual Studio 2010]
[Newtonsoft.JSON]

# License #
The Tango Card .NET 4.0/C-Sharp SDK is free to use, given some restrictions. Please see the LICENSE file for details.

# Integration #
When you're ready to go live, email [sales@tangocard.com](mailto:sales@tangocard.com). We'll get you set up with a contract and everything else you need, including linking your account so that transactions served via your integration will draw down on your Tango Card account. 
