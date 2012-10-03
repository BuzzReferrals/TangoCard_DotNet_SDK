<h1>Tango Card C#/.NET 4.0 SDK</h1>
<h3>Incorporate the innovative Tango Card directly into your reward, loyalty, and engagement applications.</h3>
<h4>Update: 2012-10-03</h4>
===

# Table of Contents #
<ul>
    <li><a href="#introduction">Introduction</a>
        <ul>
            <li><a href="#tango_card_sdks">Tango Card SDKs</a></li>
            <li><a href="#tango_card_service_api">Tango Card Service API</a></li>
            <li><a href="#incorporate_tango_card">Incorporate the Tango Card</a></li>
            <li><a href="#open_account">Open Tango Card Account</a>
                <ul>
                    <li><a href="#open_account_register">Register</a></li>
                    <li><a href="#open_account_login">Login</a></li>
                    <li><a href="#open_account_add_funds">Add Funds</a></li>
                </ul>
            </li>
        </ul>
    </li>
    <li><a href="#puchasing_options">Understanding Gift Card Purchasing Options</a>
        <ul>
            <li><a href="#puchasing_options_distribution">Distribution of Gift Cards</a></li>
            <li><a href="#puchasing_options_skus">The Tango Card and other Retailer Brand Gift Cards</a></li>
            <li><a href="#puchasing_options_denominations">Gift Card Denominations</a></li>
            <li><a href="#puchasing_options_templates">The Tango Card and custom Company Email Templates</a></li>
        </ul>
    </li>
    <li><a href="#sdk_support">Tango Card SDKs and Service API Support</a>
        <ul>
            <li><a href="#sdk_support_resolve">Resolving Issues using Fiddler 2</a></li>
        </ul>
    </li>
    <li><a href="#sdk_overview">SDK Overview</a></li>
    <li><a href="#sdk_requirements">SDK Requirements</a></li>
    <li><a href="#tango_card_service_api_requests">Tango Card Service API Requests</a>
        <ul>
            <li><a href="#tango_card_service_api_endpoints">Tango Card Service API Endpoints</a></li>
            <li><a href="#tango_card_service_api_security">Tango Card Service API Security</a></li>
        </ul>
    </li>
    <li><a href="#sdk_methods">SDK Methods</a>
        <ul>
            <li><a href="#get_available_balance">Get Available Balance</a></li>
            <li><a href="#purchase_card">Purchase Card</a></li>
        </ul>
    </li>
    <li><a href="#sdk_error_handling">SDK Error Handling</a>
        <ul>
            <li><a href="#service_failure_responses">Service Failure Responses</a></li>
            <li><a href="#sdk_error_responses">SDK Error Responses</a></li>
            <li><a href="#handling_errors">Handling Errors</a></li>
        </ul>
    </li>
    <li><a href="#sdk_contents">SDK Contents</a>
        <ul>
            <li><a href="#lib">TangoCard.Sdk</a></li>
            <li><a href="#configuration_files">configuration files</a></li>
            <li><a href="#doc">doc</a></li>
            <li><a href="#examples">TangoCard.Sdk.Examples</a></li>
            <li><a href="#unittests">TangoCard.Sdk.Unittests</a></li>
        </ul>
    </li>
    <li><a href="#sdk_development_environment">SDK Development Environment</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact_us">Contact Us</a></li>
</ul>

<a name="introduction"></a>
# Introduction #

<a name="tango_card_sdks"></a>
## Tango Card SDKs ##
The `Tango Card Service API` provides a flexible, secure, and straight forward solution for integrating into reward, loyalty, and engagement applications for purchasing the Tango Card from their funded Tango Card account on https://www.tangocard.com. 

There are several `Tango Card SDKs` currently available that use the `Tango Card Service API`:
<ul>
    <li><a href="https://github.com/tangocarddev/TangoCard_DotNet_SDK" target="_blank">Tango Card C#/.Net 4.0 SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_PHP_SDK" target="_blank">Tango Card PHP SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_Java_SDK" target="_blank">Tango Card Java SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_Ruby_SDK" target="_blank">Tango Card Ruby SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_jQuery_SDK" target="_blank">Tango Card jQuery Plugin</a></li>
</ul>

<a name="tango_card_service_api"></a>
## Tango Card Service API ##
For those developers who wish to develop directly with our `Tango Card Service API` endpoints and do not wish to use our available SDKs or need more detail of how our API is defined, the following document is available:
<ul>
    <li><a href="https://github.com/tangocarddev/General/blob/master/Tango_Card_Service_API.md" target="_blank">Tango Card Service API</a></li>
</ul>

<a name="incorporate_tango_card"></a>
## Incorporate the Tango Card ##
The Tango Card SDKs, through our <a href="https://github.com/tangocarddev/General/blob/master/Tango_Card_Service_API.md" target="_blank">Tango Card Service API</a>, allows you to incorporate the innovative Tango Card directly into your reward, loyalty, and engagement applications.

Tango Card is the "exactly what you want" gift card and allows the recipient to use their value exactly how they want – they can select a premier gift card, they can divide their value among Brands, they can use some today and save the rest for another day. They can also donate to a non-profit organization. 

Tango Card value can be used via the web or from almost any mobile device. There are no fees or expiration dates of any kind. It’s great for the recipient, and even better for you because it is an entire gift card program delivered in one card allowing you to focus on your core business. 

Tango Card solutions are already used by Microsoft Bing, FedEx, Extole, Plink, beintoo, Lead Valu, Getty Images, and many others.

<a name="open_account"></a>
## Open Tango Card Account ##

In order to use the Tango Card SDKs, it is required to open and fund a Tango Card account on https://www.tangocard.com

<a name="open_account_register"></a>
### Register ###

First, register to open a Tango Card account: <a href="https://www.tangocard.com/user/register" target="_blank">Register</a> 

The provided 'username (email address)' and 'password' will be the same as what will be used for authenticating usage of the Tango Card SDKs' methods.

<a name="open_account_login"></a>
### Login ###

Second, to verify availability of your production account by using login: <a href="https://www.tangocard.com/user/login" target="_blank">Login</a>

<a name="open_account_add_funds"></a>
### Add Funds ###

Third, in order to purchase the Tango Card through the Tango Card SDKs, there must be funds within your Tango Card account.

Fund your account here either by 'wire transfer', 'check', or 'credit card': <a href="https://www.tangocard.com/user/addfunds" target="_blank">Add Funds</a>

<a name="puchasing_options"></a>
# Understanding Gift Card Purchasing Options #

After opening and funding your Tango Card account, then you are ready to begin using the Tango Card Service API to access your account for getting available balance and for purchasing gift cards.

When you are ready to purchase a card, the Tango Card Service API has several options:

<dl>
    <dt>
    <a name="puchasing_options_distribution"></a>
    Distribution of Digital Gift Cards - parameter <code>tcSend</code> - boolean - <b>required</b></dt>
    <dd>
        Through the Tango Card Service API you can purchase Tango Card gift cards with your choice of delivery:
        <ul>
            <li><code>tcSend = true</code> - Have Tango Card service send gift cards directly to recipients via email which will include live gift card codes.</li>
            <li><code>tcSend = false</code> - You take the returned live gift card codes for you to customize and redistribute.</li>
        </ul>
    </dd>
    
    <dt>
    <a name="puchasing_options_skus"></a>
    The Tango Card and other Retailer Brand Gift Cards SKUs - parameter <code>cardSKU</code> - string - <b>required</b></dt>
    <dd>The API is optimized for ordering the Tango Card, which is SKU <code>"tango-card"</code>.

    <br>If you have questions about potentially incorporating other brands or digital goods in your program, then please do contact us at <a href="mailto:sdk@tangocard.com?Subject=Tango Card C#/.NET 4.0 SDK Question">sdk@tangocard.com</a>.
    </dd>
    
    <dt>
    <a name="puchasing_options_denominations"></a>
    Gift Card Denominations - parameter <code>cardValue</code> - integer - <b>required</b></dt>
    <dd>Each gift card SKU has it own allowed set of denominations that can to assigned to parameter <code>cardValue</code>.
    <br/>For SKU <code>"tango-card"</code>, the available denomination in cents is between <code>1</code> ($0.01) to <code>100000</code> ($1000.00).
    <br/>To find out about other available denominations for potentially incorporating other SKUs that can be assigned to parameter <code>cardValue</code>, then please do contact us at <a href="mailto:sdk@tangocard.com?Subject=Tango Card C#/.NET 4.0 SDK Question">sdk@tangocard.com</a>.
    </dd>
    
    <dt>
    <a name="puchasing_options_templates"></a>
    The Tango Card and custom Company Email Templates - parameter <code>companyIdentifier</code> - string - <b>optional</b></dt>
    <dd>If you choose to have the Tango Card Service API send digital gift cards by setting <code>tcSend</code> to <code>true</code>, then by default the gift card information within a Tango Card email template.
    <br>If you prefer to have the Tango Card Service API send the gift card information with a custom email template (with your own branding), then please do contact us at <a href="mailto:sdk@tangocard.com?Subject=Tango Card C#/.NET 4.0 SDK Question">sdk@tangocard.com</a>.
    </dd>
</dl>

<a name="sdk_support"></a>
# Tango Card SDKs and Service API Support #
If you have any questions with the Tango Card C#/.NET 4.0 SDK or our Service API, please contact us at <a href="mailto:sdk@tangocard.com?Subject=Tango Card C#/.NET 4.0 SDK Question">sdk@tangocard.com</a>.

<a name="sdk_support_contact"></a>
## Contact Us ##
To learn more about Tango Card integration solutions, call 1.877.55.TANGO.

<a name="sdk_support_resolve"></a>
## Resolving Issues using Fiddler 2 ##

The best way to resolve any issues that pertain to using our Tango Card C#/.NET 4.0 SDK or our Tango Card Service API is by using this freely available tool <a href="http://www.fiddler2.com/fiddler2/" target="_blank">`Fiddler 2 - Web Debugging Proxy`</a>, and providing us with the raw request and response bodies using its `Inspectors` tab feature.

Using `Fiddler 2` will provide us with the most complete detail and the fastest response from Tango Card by understanding if there is an issue on how a request was presented to our service, or if it is an issue with our service on how we replied to your request.

### Fiddler 2 Example - Raw Request from Client - Get Available Balance ###

```Text
POST https://int.tangocard.com/Version2/GetAvailableBalance HTTP/1.1
Accept: application/json, text/javascript, */*; q=0.01
Accept-Language: en-us
Content-Type: application/json; charset=UTF-8
Accept-Encoding: gzip, deflate
User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)
Host: int.tangocard.com
Content-Length: 69
Connection: Keep-Alive
Cache-Control: no-cache
 
{"username":"third_party_int@tangocard.com","password":"integrateme"}
```
 
### Fiddler 2 Example - Raw Response from Service - Get Available Balance ###

```Text
HTTP/1.1 200 OK
Date: Wed, 26 Sep 2012 04:30:36 GMT
Server: Apache/2.2.22 (Ubuntu)
X-Powered-By: PHP/5.3.10-1ubuntu3.3
Access-Control-Allow-Origin: *
Content-Length: 68
Connection: close
Content-Type: application/json
 
{"responseType":"SUCCESS","response":{"availableBalance":873431432}}
```

<a name="sdk_overview"></a>
# SDK Overview #

The Tango Card C#/.NET 4.0 SDK is a wrapper around the <a href="https://github.com/tangocarddev/General/blob/master/Tango_Card_Service_API.md" target="_blank">Tango Card Service API</a>.

As such, it has two primary types of objects, Requests and Responses; which are handled by a wrapper class `TangoCard.Sdk.TangoCardServiceApi`.

The wrapper class `TangoCard.Sdk.TangoCardServiceApi` currently handles the following static methods:
<dl>
    <dt>bool GetAvailableBalance()</dt>
    <dd>- Gather the currently available balance for provided user within their www.tangocard.com account.</dd>

    <dt>bool PurchaseCard()</dt>
    <dd>- Purchase a gift card using funds from user's www.tangocard.com account.</dd>
</dl>

![Tango Card Service Api](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/master/doc/images/tangocardserviceapi.png "Tango Card Service API")

<a name="sdk_requirements"></a>
# SDK Requirements #

## Environment Required ##

* [.NET 4.0](http://www.microsoft.com/en-us/download/details.aspx?id=17851)
* [Visual Studio 2010](http://www.microsoft.com/visualstudio/en-us/products/2010-editions)  
* [Newtonsoft.JSON](http://james.newtonking.com/projects/json-net.aspx)

<a name="sdk_requirements_build"></a>
## Binary Builds ##

This SDK provides two binary builds:

<dl>
    <dt><code>DEBUG</code></dt>
        <dl>
            Files required to be included within the web service's <code>bin</code> directory when running in debug mode:
            <ul>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Debug\Newtonsoft.Json.dll</code></li>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Debug\TangoCard_DotNet_SDK.dll</code></li>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Debug\TangoCard_DotNet_SDK.dll.config</code></li>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Debug\TangoCard_DotNet_SDK.pdb</code></li>
            </ul>
        </dl>
    <dt><code>RELEASE</code></dt>
        <dl>
            Files required to be included within the web service's <code>bin</code> directory when running in release mode:
            <ul>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Release\Newtonsoft.Json.dll</code></li>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Release\TangoCard_DotNet_SDK.dll</code></li>
                <li><code>\TangoCard_DotNet_SDK\master\bin\Release\TangoCard_DotNet_SDK.dll.config</code></li>
            </ul>
        </dl>
</dl>

<a name="tango_card_service_api_requests"></a>
# Tango Card Service API Requests #

With the <a href="https://github.com/tangocarddev/General/blob/master/Tango_Card_Service_API.md" target="_blank">Tango Card Service API</a>, every request has a corresponding success-case response object. There are also several failure-case response objects which are shared between calls. The specifics of the request and response objects will be described in <a href="#sdk_methods">Tango Card SDK Methods</a>.

<a name="tango_card_service_api_endpoints"></a>
## Tango Card Service API Endpoints ##

Available are two endpoints that provide the <a href="https://github.com/tangocarddev/General/blob/master/Tango_Card_Service_API.md" target="_blank">Tango Card Service API</a>, as defined by `enum TangoCard.Sdk.Service.TangoCardServiceApiEnum` :
<dl>
    <dt><code>INTEGRATION</code></dt> 
    <dd>
        <ul>
            <li>Expected to be used for development and testing purposes.</li>
            <li><b>Important:</b> Purchases from this endpoint will: 
                <ul>
                    <li>Use funds from our test account.</li>
                    <li>Send real emails (with fake codes), so only use recipient email addresses you control for testing purposes.</li>
                </ul>
            </li>
            <li>Secure Endpoint URL: <code>https://int.tangocard.com/Version2</code></li>
            <li>Login to use our testing account through this endpoint is:
                <dl>
                    <dt>Username:</dt>
                    <dd>third_party_int@tangocard.com</dd>
                    <dt>Password:</dt>
                    <dd>integrateme</dd>
                </dl>
            </li>
        </ul>
    </dd>
    <dt><code>PRODUCTION</code></dt>
    <dd>
        <ul>
            <li>Performs actual card purchase requests.</li>
            <li><b>Important:</b> Purchases from this endpoint will: 
                <ul>
                    <li>Use funds from <b>your Tango Card account</b>!</li>
                    <li>Send real emails (with live codes), only use recipient email addresses you wish to deliver to.</li>
                </ul>
            </li>
            <li>Endpoint URL: <code>https://api.tangocard.com/Version2</code></li>
            <li>Login to use your production account through this endpoint is:
                <dl>
                    <dt>Username:</dt>
                    <dd>Your Tango Card account's username (email address)</dd>
                    <dt>Password:</dt>
                    <dd>Your Tango Card account's password</dd>
                </dl>
            </li>
        </ul>
    </dd>
</dl>

<a name="tango_card_service_api_security"></a>
## Tango Card Service API Security ##

<a href="https://github.com/tangocarddev/General/blob/master/Tango_Card_Service_API.md" target="_blank">Tango Card Service API</a> Requests are performed using secure HTTP POST via <a href="http://en.wikipedia.org/wiki/Transport_Layer_Security" target="_blank">"TLS/SSL"</a>.

The use of SSL allows for securely transmitting data and prevents <a href="http://en.wikipedia.org/wiki/Man-in-the-middle_attack" target="_blank">man-in-the-middle attacks</a>.

The lack of sessions and the inability to communicate with the API over HTTP prevents <a href="http://en.wikipedia.org/wiki/Session_hijacking" target="_blank">session hijacking</a> and <a href="http://en.wikipedia.org/wiki/Cross-site_request_forgery" target="_blank">cross-site request forgery</a>.

<a name="sdk_methods"></a>
# SDK Methods #

<a name="get_available_balance"></a>
## Get Available Balance ##

![Tango Card Service API - GetAvailableBalance()](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/master/doc/images/tangocardserviceapi_getavailablebalance.png "Tango Card Service API - GetAvailableBalance()")

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

Assuming success, the `out` parameter `response` will be an instance of `TangoCard.Sdk.Response.Success.GetAvailableBalanceResponse`.

### Method TangoCard.Sdk.TangoCardServiceApi.GetAvailableBalance() ###

#### Parameters ####
<dl>
    <dt>[IN] * enumTangoCardServiceApi</dt>
    <dd><code>TangoCardServiceApiEnum</code> - <b>required</b> - <code>INTEGRATION</code> or <code>PRODUCTION</code></dd>

    <dt>[IN] * username</dt>
    <dd>string - <b>required</b> - user account's username registered within Tango Card production website (https://www.tangocard.com).</dd>

    <dt>[IN] * password</dt>
    <dd>string - <b>required</b> - user account's password registered within Tango Card production website (https://www.tangocard.com)</dd>

    <dt>[OUT] response</dt>
    <dd><code>TangoCard.Sdk.Response.Success.GetAvailableBalanceResponse</code> - This <i>out</i> parameter will provide a valid success response object if this method returns <code>true</code> upon success.</dd>
</dl>

### `TangoCard.Sdk.Response.Success.GetAvailableBalanceResponse` Properties ###

<dl>
  <dt>int getAvailableBalance</dt>
  <dd>- Returns available balance of username's account in cents: 100 is $1.00 dollar.</dd>
</dl>

<a name="purchase_card"></a>
## Purchase Card ##

![Tango Card Service API - PurchaseCard()](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/master/doc/images/tangocardserviceapi_purchasecard.png "Tango Card Service API - PurchaseCard()")

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
            giftFrom: "Bill Company",
            giftMessage: "Happy Birthday",
            recipientEmail: "sally@example.com",
            recipientName: "Sally Example",
            companyIdentifier: null,
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

Assuming success, the `out` parameter `response` will be an instance of `TangoCard.Sdk.Response.Success.PurchaseCardResponse`.

### Method TangoCard.Sdk.TangoCardServiceApi.PurchaseCard() ###

#### Parameters ###

<dl>
    <dt>[IN] * enumTangoCardServiceApi</dt>
    <dd><code>TangoCardServiceApiEnum</code> - <b>required</b> - <code>INTEGRATION</code> or <code>PRODUCTION</code></dd>

    <dt>[IN] * username</dt>
    <dd>string - <b>required</b> - user account's username registered within Tango Card production website (https://www.tangocard.com).</dd>

    <dt>[IN] * password</dt>
    <dd>string - <b>required</b> - user account's password registered within Tango Card production website (https://www.tangocard.com)</dd>

    <dt>[IN] * cardSku</dt>
    <dd>string - <b>required</b> - The SKU of the card to purchase. The SKU for the Tango Card is "tango-card". See: <a href="#puchasing_options_skus">Purchase Option of Gift Card Brands</a></dd>

    <dt>[IN] * cardValue</dt>
    <dd>integer - <b>required</b> - The value of the card to purchase in cents (100 = $1.00). See: <a href="#puchasing_options_denominations">Purchase Option for Denominations</a></dd>

    <dt>[IN] * tcSend</dt>
    <dd>boolean - <b>required</b> - Determines if Tango Card Service will send an email with gift card information to recipient. See: <a href="#puchasing_options_distribution">Purchase Option for Distribution</a>.</dd>

    <dt>[IN] * recipientName</dt>
    <dd>string (length 1 - 255) or null - <b>required</b> if parameter <code>tcSend</code> is <code>true</code>, else ignored - The name of the person receiving the card.</dd>

    <dt>[IN] * recipientEmail</dt>
    <dd>string (length 3 - 255) or null - <b>required</b> if parameter <code>tcSend</code> is <code>true</code>, else ignored - The email address of the person receiving the card.</dd>

    <dt>[IN] * giftMessage</dt>
    <dd>string (length 1 - 255) or null - <b>required</b> if parameter <code>tcSend</code> is <code>true</code>, else ignored - A message from the sender of the card to the recipient. May be null, but must exist if tcSend = true.</dd>

    <dt>[IN] giftFrom</dt>
    <dd>string (length 1 - 255) or null - <b>optional</b> if parameter <code>tcSend</code> is <code>true</code>, else ignored - The name of the person sending the card.</dd>

    <dt>[IN] companyIdentifer</dt>
    <dd>string (length 1 - 255) or null - <b>optional</b> if parameter <code>tcSend</code> is <code>true</code>, else ignored - The email-template identifier. Ignored or value <code>null</code> will use the Tango Card Email Template. See: <a href="#puchasing_options_templates">Purchase Option for Email Templates</a>.</dd>

    <dt>[OUT] response</dt>
    <dd><code>TangoCard.Sdk.Response.Success.PurchaseCardResponse</code> - This <i>out</i> parameter will provide a valid success response object if this method returns <code>true</code> upon success.</dd>
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

<a name="sdk_error_handling"></a>
# SDK Error Handling #

The Tango Card C#/.NET 4.0 SDK handles its errors by throwing the following exceptions:

* Custom `TangoCard.Sdk.Service.TangoCardServiceException` is thrown when the `Tango Card Service API` return a `Failure Response` for a given `Request`.
* Custom `TangoCard.Sdk.Common.TangoCardSdkException` is thrown when the Tango Card SDK has detected an error within its code, regardless of any given Request.
* Standard `java.lang.IllegalArgumentException` is thrown due to parameter entry errors.

![Tango Card SDK Exceptions](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/master/doc/images/tangocard_sdk_exceptions.png "Tango Card SDK Exceptions")

<a name="service_failure_responses"></a>
## Service Failure Responses ##

The `Tango Card SERVICE API` handles its errors by returning the following failure responses as enumerated by `TangoCard.Sdk.Response.ServiceResponseEnum`:

<table>
    <tr><th>Failure</th><th>Failure Reponse Type</th><th>Failure Response Object</th></tr>
    <tr><td>Insufficient Funds</td><td>INS_FUNDS</td><td>`TangoCard.Sdk.Response.Failure.InsufficientFundsResponse`</td></tr>
    <tr><td>Insufficient Inventory</td><td>INS_INV</td><td>`TangoCard.Sdk.Response.Failure.InsufficientInventoryResponse`</td></tr> 
    <tr><td>Invalid Credentials</td><td>INV_CREDENTIAL</td><td>`TangoCard.Sdk.Response.Failure.InvalidCredentialsResponse`</td></tr> 
    <tr><td>Invalid Input</td><td>INV_INPUT</td><td>`TangoCard.Sdk.Response.Failure.InvalidInputResponse`</td></tr>
    <tr><td>System Failure</td><td>SYS_ERROR</td><td>`TangoCard.Sdk.Response.Failure.SystemFailureResponse`</td></tr>
</table>

Each of the aforementioned `Failure Responses` contains details as to the reason that the `Tango Card Service API` did not perform provided `Request`.

![Tango Card SDK Service Response Failures](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/master/doc/images/tangocard_sdk_service_failure_response.png "Tango Card SDK Service Response Failures")

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

<a name="sdk_error_responses"></a>
## SDK Error Responses ##

This SDK throws it own custom exception `TangoCard.Sdk.Common.TangoCardSdkException` when detecting errors that pertain to itself.

![Tango Card SDK Error Detection](https://github.com/tangocarddev/TangoCard_DotNet_SDK/raw/master/doc/images/tangocard_sdk_error_detected.png "Tango Card SDK Error Detection")

<a name="handling_errors"></a>
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

<a name="sdk_contents"></a>
# SDK Contents #
This section details the provided sources of this SDK.

<a name="tangoCard_sdk"></a>
## TangoCard.Sdk ##
This is the heart of the SDK which contains the sources, and here is a listing of its directories:

* TangoCard.Sdk\Common
* TangoCard.Sdk\Request
* TangoCard.Sdk\Response
* TangoCard.Sdk\Response\Failure
* TangoCard.Sdk\Response\Success
* TangoCard.Sdk\Service

<a name="configuration_files"></a>
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

<a name="doc"></a>
## doc ##

The `doc\help\Index.html` accesses the up-to-date [Sandcastle Documentation Compiler](http://sandcastle.codeplex.com/) generated documentation for the classes (and functions) that are included in the SDK.

See [Visual Studio 2010 Sandcastle Help File Builder](http://shfb.codeplex.com/) project `TangoCard.Sdk.Help`.

<a name="examples"></a>
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

<a name="unittests"></a>
## TangoCard.Sdk.Unittests ##

The SDK's unittests have been written to use [Visual Studio 2010][UnitTest Project].

* `UnitTest_GetAvailableBalance`
* `UnitTest_PurchaseCard`

#### UnitTest Command Line Run ####

To run these unit tests requires installation of Visual Studio 2010 Professional.

Open a Visual Studio 2010 command prompt. 

To do this, click Start, point to All Programs, point to Microsoft Visual Studio 2010, point to Visual Studio Tools, and then click <a href="http://msdn.microsoft.com/en-us/library/ms229859(v=vs.100).aspx" target="_blank" >`Visual Studio 2010 Command Prompt`</a> and perform unit test using <a href="http://msdn.microsoft.com/en-us/library/ms182489(v=vs.80).aspx" target="_blank">`MSTest`</a>.

```Text
    > MSTest /testcontainer:TangoCard.Sdk.Unittests\bin\Release\TangoCard.Sdk.Unittests.dll
    
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

<a name="sdk_development_environment"></a>
# SDK Development Environment #

This C#/.NET 4.0 SDK was built using:

* [.NET 4.0](http://www.microsoft.com/en-us/download/details.aspx?id=17851)
* [Visual Studio 2010 Ultimate](http://www.microsoft.com/visualstudio/en-us/products/2010-editions/ultimate/overview)
* [Newtonsoft.JSON](http://james.newtonking.com/projects/json-net.aspx) 

<a name="license"></a>
# License #

The Tango Card C#/.NET 4.0 SDK is free to use, given some restrictions. Please see the <a href="https://github.com/tangocarddev/TangoCard_Java_SDK/blob/master/LICENSE.md" target="_blank">LICENSE</a> file for details.

<a name="contact_us"></a>
# Contact Us #
If you have any questions about using this SDK, please do contact us at <a href="mailto:sdk@tangocard.com?Subject=Tango Card C#/.NET 4.0 SDK Question">sdk@tangocard.com</a> 

To learn more about Tango Card integration solutions, call 1.877.55.TANGO.