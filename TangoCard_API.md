<h1>Tango Card API</h1>
<h3>Purchasing the Tango Card through Tango Card API endpoint</h3>
===

# Table of Contents #
<ul>
    <li><a href="#introduction">Introduction</a>
        <ul>
            <li><a href="#tango_card_api">Tango Card API</a>
                <ul>
                    <li><a href="#tango_card_sdks">Tango Card SDKs</a></li>
                </ul>
            </li>
            <li><a href="#incorporate_tango_card">Incorporate the Tango Card</a></li>
            <li><a href="#open_account">Open Tango Card Account</a>
                <ul>
                    <li><a href="#open_account_register">Register</a></li>
                    <li><a href="#open_account_login">Login</a></li>
                    <li><a href="#open_account_add_funds">Add Funds</a></li>
                </ul>
            </li>
            <li><a href="#start_using">Start Using</a>
                <ul>
                    <li><a href="#start_using_purchase">Purchase and Distribution of Gift Cards</a></li>
                    <li><a href="#start_using_gift_cards">The Tango Card and other Retailer Brand Gift Cards</a></li>
                </ul>
            </li>
            <li><a href="#api_support">API Support</a></li>
            <li><a href="#contact_us">Contact Us</a></li>
        </ul>
    </li>
    <li><a href="#tango_card_api_overview">Tango Card API Overview</a>
        <ul>
            <li><a href="#tango_card_service_requests">Tango Card Service Requests</a>
                <ul>
                    <li><a href="#http_post_request_body">HTTP POST Request Body</a></li>
                    <li><a href="#request_methods">Request Methods</a></li>
                    <li><a href="#response_body">Response Body</a></li>
                </ul>
            </li>
            <li><a href="#tango_card_service_api_endpoints">Tango Card Service API Endpoints</a></li>
            <li><a href="#tango_card_service_api_security">Tango Card Service API Security</a></li>
        </ul>
    </li>
    <li><a href="#tango_card_api_methods">Tango Card API Methods</a>
        <ul>
            <li><a href="#request_getavailablebalance">GetAvailableBalance</a>
                <ul>
                    <li><a href="#getavailablebalance_request_params">Request Parameters</a></li>
                    <li><a href="#getavailablebalance_response_types">Response Types</a></li>
                </ul>
            </li>
            <li><a href="#request_purchasecard">PurchaseCard</a>
                <ul>
                    <li><a href="#purchasecard_request_params">Request Parameters</a></li>
                    <li><a href="#purchasecard_response_types">Response Types</a></li>
                </ul>
            </li>
        </ul>
    </li>
    <li><a href="#failure_response_types">Failure Response Types</a>
        <ul>
            <li><a name="failure_response_sys_error" >SYS_ERROR</a></li>
            <li><a name="failure_response_inv_input" >INV_INPUT</a></li>
            <li><a name="failure_response_inv_credential" >INV_CREDENTIAL</a></li>
            <li><a name="failure_response_ins_inv" >INS_INV</a></li>
            <li><a name="failure_response_ins_funds" >INS_FUNDS</a></li>
        </ul>
    </li>
</ul>

<a name="introduction"></a>
# Introduction #

<a name="tango_card_api"></a>
## Tango Card API ##
Tango Card's API is flexible, secure, and straightforward. It allows any server to purchase the Tango Card and is intended for users requiring high volume transactions and processes.

<a name="tango_card_sdks"></a>
### Tango Card SDKs ###
For those developers that do not wish to develop directly with our Tango Card API, there are several Tango Card SDKs currently available that use the Tango Card API:
<ul>
    <li><a href="https://github.com/tangocarddev/TangoCard_DotNet_SDK" target="_blank">Tango Card C#/.Net 4.0 SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_PHP_SDK" target="_blank">Tango Card PHP SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_Java_SDK" target="_blank">Tango Card Java SDK</a></li>
</ul>

<a name="incorporate_tango_card"></a>
## Incorporate the Tango Card ##
Tango Card API allows you to incorporate the innovative the Tango Card into your reward, loyalty, and engagement applications. 

Tango Card is the “exactly what you want” gift card and allows the recipient to use their value exactly how they want – they can select a premier gift card, they can divide their value among Brands, they can use some today and save the rest for another day. They can also donate to a non-profit organization. 

Tango Card value can be used via the web or from almost any mobile device. There are no fees or expiration dates of any kind. It’s great for the recipient, and even better for you because it is an entire gift card program delivered in one card allowing you to focus on your core business. 

Tango Card solutions are already used by Microsoft Bing, FedEx, Extole, Plink, beintoo, Lead Valu, Getty Images, and many others.

<a name="open_account"></a>
## Open Tango Card Account ##

In order to use the Tango Card API, it is required to open and fund a Tango Card account on https://www.tangocard.com

<a name="open_account_register"></a>
### Register ###

First, register to open a Tango Card account: <a href="https://www.tangocard.com/user/register" target="_blank">Register</a> 

The provided 'username (email address)' and 'password' will be the same as what will be used for authenticating usage of the Tango Card API's methods.

<a name="open_account_login"></a>
### Login ###

Second, to verify availability of your production account by using login: <a href="https://www.tangocard.com/user/login" target="_blank">Login</a>

<a name="open_account_add_funds"></a>
### Add Funds ###

Third, in order to purchase the Tango Card through the Tango Card API, there must be funds within your Tango Card account.

Fund your account here either by 'wire transfer', 'check', or 'credit card': <a href="https://www.tangocard.com/user/addfunds" target="_blank">Add Funds</a>

<a name="start_using"></a>
## Start Using ##

After opening and funding your Tango Card account, then you are ready to begin using the Tango Card API to access your account.

<a name="start_using_purchase"></a>
### Purchase and Distribution of Gift Cards ###
Through the Tango Card API you can purchase Tango Card gift cards with your choice of delivery:
<ul>
    <li>Have Tango Card service send gift cards directly to recipients via email which will include live gift card codes.</li>
    <li>You take the returned live gift card codes for you to customize and redistribute.</li>
</ul>

<a name="start_using_gift_cards"></a>
### The Tango Card and other Retailer Brand Gift Cards ###

The API is optimized for ordering the Tango Card, which has SKU of ```"tango-card"```.

If you have questions about potentially incorporating other brands or digital goods in your program please contact us at general@tangocard.com.

<a name="sdk_support"></a>
## Tnngo Card API Support ##
If you have any questions with the Tango Card API, please contact us at sdk@tangocard.com.

<a name="contact_us"></a>
## Contact Us ##
To learn more about Tango Card integration solutions, call 1.877.55.TANGO.

<a name="tango_card_api_overview"></a>
# Tango Card API Overview #

<a name="tango_card_api_requests"></a>
## Tango Card API Requests ##

The Tango Card SDK, every Request has a corresponding success-case Response object.

<a name="http_post_request_body"></a>
### HTTP POST Request Body ###
All requests are via JSON-encoded objects as the payload of a HTTP POST call on a specified method. As an example, if the input listed below was "sku" then the POST body might look like:

```json
{"sku":"tango-card"}
```

Note, however that since this is an HTTP POST that this should be <a href="http://en.wikipedia.org/wiki/Percent-encoding">"percent-encoded"</a>, as normal, so the actual body might actually look more like:

```text
%7B%22sku%22%3A%22tango-card%22%7D
```

<a name="request_methods"></a>
### Request Methods ###

The available request methods through our API endpoints are:
<dl>
    <dt>GetAvailableBalance</dt>
    <dd>Request the available balance to the user whose authentication was supplied..</dd>
    <dt>PurchaseCard</dt>
    <dd>Purchase Tango Cards from account funded by user.</dd>
</dl>

<a name="response_body"></a>
### Response Body ###

All responses are a JSON-encoded object with the format of:

<dl>
    <dt>"responseType":</dt
    <dd>STRING</dd>
    <dt>"response":<dt>
    <dd>JSON OBJECT</dd>
</dl>
  
The value of "responseType" will influence the format of the object in response. For "responseType" of "SUCCESS", then the "response" will provide a JSON-encoded object with requested data. For other "responseType" cases are considered failure response and are detailed within section below <a href="#failure_response_types">Failure Response Types</a>.

<a name="tango_card_service_api_endpoints"></a>
## Tango Card Service API Endpoints ##

Available are two endpoints that provide the Tango Card Service API:
<dl>
    <dt>Integration Endpoint</dt> 
    <dd>
        <ul>
            <li>Expected to be used for development and testing purposes.</li>
            <li><b>Important:</b> Purchases from this endpoint will: 
                <ul>
                    <li>Use funds from our test account.</li>
                    <li>Send real emails (with fake codes), so only use recipient email addresses you control for testing purposes.</li>
                </ul>
            </li>
            <li>Endpoint URL: https://int.tangocard.com/Version2/[method]</li>
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
    <dt>Production Endpoint</dt>
    <dd>
        <ul>
            <li>Performs actual card purchase requests.</li>
            <li><b>Important:</b> Purchases from this endpoint will: 
                <ul>
                    <li>Use funds from <b>your Tango Card account</b>!</li>
                    <li>Send real emails (with live codes), only use recipient email addresses you wish to deliver to.</li>
                </ul>
            </li>
            <li>Endpoint URL: https://api.tangocard.com/Version2/[method]</li>
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

Requests are secure HTTP POST using SSL.

All calls are made via <a href="http://technet.microsoft.com/en-us/library/cc784450(v=ws.10).aspx">"TLS/SSL"</a>.

<a name="tango_card_api_methods"></a>
# Tango Card API Methods #

<a name="request_getavailablebalance"></a> 
## GetAvailableBalance ##

<dl>
    <dt>Description</dt>
    <dd>Request the available balance to the user whose authentication was supplied.</dd>
</dl>

<a name="getavailablebalance_request_params"></a>
### Request Parameters ###
<dl>
    <dt>username</dt>
    <dd>https://www.tangocard.com user account's username</dd>
    <dt>password</dt>
    <dd>https://www.tangocard.com user account's password</dd>
</dl>

<a name="getavailablebalance_response_types"></a>
### Response Types ###

<dt>Success Response Type:</dt>
<dd>
    <dl>
        <dt>SUCCESS</dt>
        <dd>JSON Object:
            <dl>
                <dt>availableBalance</dt>
                <dd>integer - The balance available to the user in cents (100 = $1.00).</dd>
            </dl>
        </dd>
    </dl>
</dd>
<dt>Failure Response Types:</dt>
<dd>See details for each within next section.
    <dl>
        <dt>SYS_ERROR</dt>
        <dt>INV_CREDENTIAL</dt>
    </dl>
</dd>
</dl>

<a name="request_purchasecard"></a>
## PurchaseCard ##

<dl>
    <dt>Description</dt>
    <dd>Purchase a single card to be delivered as described.</dd>
</dl>

<a name="purchasecard_request_params"></a>
### Request Parameters ###
<dl>
    <dt>username</dt>
    <dd>https://www.tangocard.com user account's username</dd>
    <dt>password</dt>
    <dd>https://www.tangocard.com user account's password</dd>
    <dt>cardSku</dt>
    <dd>string - The SKU of the card to purchase. The SKU for the Tango Card is "tango-card". For other SKUs, please refer to this section: <a href="#start_using_gift_cards">The Tango Card and other Retailer Brand Gift Cards</a></dd>
    <dt>cardValue</dt>
    <dd>integer - The value of the card to purchase.</dd>
    <dt>tcSend</dt>
    <dd>boolean - Whether Tango Card will send the email to the user.</dd>
    <dt>recipientName</dt>
    <dd>string (length 1 - 255, required if tcSend=true) - The name of the person receiving the card.</dd>
    <dt>recipientEmail</dt>
    <dd>string (length 3 - 255, required if tcSend=true) - The email address of the person receiving the card.</dd>
    <dt>giftMessage</dt>
    <dd>string (length 1 - 255, required if tcSend=true) - A message from the sender of the card to the recipient. May be null, but must exist if tcSend = true.</dd>
    <dt>giftFrom</dt>
    <dd>string (length 1 - 255, required if tcSend=true) - The name of the person sending the card.</dd>
</dl>

<a name="purchasecard_response_types"></a>
### Response Types ###

<dl>
<dt>Success Response Type:</dt>
<dd>
    <dl>
        <dt>SUCCESS</dt>
        <dd>JSON Object:
            <dl>
                <dt>referenceOrderId</dt>
                <dd>string - A unique token that we can use to look up the order.</dd>
                <dt>cardToken</dt>
                <dd>string - A unique token that we can use to look up the card.</dd>
                <dt>cardNumber</dt>
                <dd>string - The card’s "number".</dd>
                <dt>cardPin</dt>
                <dd>string - The card’s "pin", may be null.</dd>
            </dl>
        </dd>
    </dl>
</dd>
<dt>Failure Response Types:</dt>
<dd>See details for each within next section.
    <dl>
        <dt>SYS_ERROR</dt>
        <dt>INV_CREDENTIAL</dt>
        <dt>INV_INPUT</dt>
        <dt>INS_INV</dt>
        <dt>INS_FUNDS</dt>
    </dl>
</dd>
</dl>


<a name="failure_response_types" ></a>
# Failure Response Types #

Here are the following expect failure response types that can be returned from Tango Card API endpoint.

<a name="failure_response_sys_error" ></a>
## SYS_ERROR ##

An error happened on our end. The call may may be re-tried, however if the error persists please contact us.

<dl>
    <dt>errorCode<dt>
    <dd>string - An internal error code that we can use to track down where the error occurred.</dd>
</dl>
    
<a name="failure_response_inv_input" ></a>
## INV_INPUT ##

One (or more) of the supplied inputs didn’t meet the requirements. The request should be altered before resubmitting.

<dl>
    <dt>invalid<dt>
    <dd>JSON object - The object’s properties are the name of the invalid field, the value of the property is description of the associated problem.</dd>
</dl>
    
<a name="failure_response_inv_credential" ></a>
## INV_CREDENTIAL ##

The credential was either missing, or something was wrong with it. The request should be altered before resubmitting.

<dl>
    <dt>message<dt>
    <dd>string - A description of what appeared to be wrong with the supplied credential.</dd>
</dl>
    
<a name="failure_response_ins_inv" ></a>
## INS_INV ##

We don’t have enough available inventory to fulfill the request. The request should be altered before resubmitting.

<dl>
    <dt>sku<dt>
    <dd>string - The SKU that we couldn’t fulfill.</dd>
    <dt>value<dt>
    <dd>integer - The value that we couldn’t fulfill.</dd>
</dl>
    
<a name="failure_response_ins_funds" ></a>
## INS_FUNDS ##

The account associated with the authenticated user doesn’t have enough available balance to cover the cost of the purchase.

<dl>
    <dt>availableBalance<dt>
    <dd>integer - The balance currently available in cents (100 = $1.00).</dd>
    <dt>orderCost<dt>
    <dd>integer - The amount the order would cost to complete in cents (100 = $1.00).</dd>
</dl>
    
  

