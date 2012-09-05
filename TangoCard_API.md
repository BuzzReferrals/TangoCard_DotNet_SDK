<h1>Tango Card API</h1>
<h3>Digital gift cards in minutes</h3>
===

# Table of Contents #
<ul>
    <li><a href="#introduction">Introduction</a>
        <ul>
            <li><a href="#tango_card_api">Tango Card API</a></li>
            <li><a href="#incorporate_tango_card">Incorporate Tango Card Gift Cards</a></li>
            <li><a href="#open_account">Open Tango Card Account</a></li>
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
                </ul>
            </li>
            <li><a href="#tango_card_service_api_endpoints">Tango Card Service API Endpoints</a></li>
            <li><a href="#tango_card_service_api_security">Tango Card Service API Security</a></li>
        </ul>
    </li>
    <li><a href="#tango_card_api_methods">Tango Card API Methods
        <ul>
            <li><a href="#request_getavailablebalance">GetAvailableBalance</a></li>
            <li><a href="#request_purchasecard">PurchaseCard</a></li>
        </ul>
    </li>
    <li><a href="#responses">Responses</a>
    </li>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
</ul>

<a name="introduction"></a>
# Introduction #

<a name="tango_card_api"></a>
## Tango Card API ##
Tango Card's API is flexible, secure, and straightforward. It allows any server to purchase gift cards and is intended for users requiring high volume transactions and processes. While simple enough that developers can start integrating within 15 minutes, it is robust enough so developers don't have to deal with JSON or setting up secure network connections with our server.

<a name="tango_card_sdks"></a>
## Tango Card SDKs ##
There are several Tango Card SDKs currently available that use the Tango Card API:
<ul>
    <li><a href="https://github.com/tangocarddev/TangoCard_DotNet_SDK" target="_blank">Tango Card C#/.Net 4.0 SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_PHP_SDK" target="_blank">Tango Card PHP SDK</a></li>
    <li><a href="https://github.com/tangocarddev/TangoCard_Java_SDK" target="_blank">Tango Card Java SDK</a></li>
</ul>

<a name="incorporate_tango_card"></a>
## Incorporate Tango Card Gift Cards ##
Tango Card’s Extend API allow you to incorporate the innovative Tango Card gift card into your reward, loyalty, and engagement applications. Tango Card is the “exactly what you want” gift card and allows the recipient to use their value exactly how they want – they can select a premier gift card, they can divide their value among Brands, they can use some today and save the rest for another day. They can also donate to a non-profit organization. Tango Card value can be used via the web or from almost any mobile device. There are no fees or expiration dates of any kind. It’s great for the recipient, and even better for you because it is an entire gift card program delivered in one card allowing you to focus on your core business. Tango Card solutions are already used by Microsoft Bing, FedEx, Extole, Plink, beintoo, Lead Valu, Getty Images, and many others.

<a name="open_account"></a>
## Open Tango Card Account ##
Within minutes of download, our Extend SDKs will allow you to check the balance on your pre-funded Tango Card account, send Tango Card gift cards directly to recipients via email, and return live gift card codes for you to customize and redistribute. With Tango Card and Retailer Brand approval, there is also the ability to order retailer Brand gift cards via the SDK. Simply use the supplied credentials to see how easy it is. When you’re ready to move into production, sign up for an account at https://www.tangocard.com/user/register. Use these credentials in your SDK and you’re done!

<a name="sdk_support"></a>
## SDK Support ##
If you have any questions, please contact us at sdk@tangocard.com.

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

<a name="tango_card_service_api_endpoints"></a>
## Tango Card Service API Endpoints ##

Available are two endpoints that provide the Tango Card Service API, as defined by `enum TangoCard.Sdk.Service.TangoCardServiceApiEnum` :
<dl>
    <dt>INTEGRATION</dt> 
    <dd>
        <ul>
            <li>Expected to be used for development and testing purposes.</li>
            <li>https://int.tangocard.com/Version2/[method]</li>
        </ul>
    </dd>
    <dt>PRODUCTION</dt>
    <dd>
        <ul>
            <li>Performs actual card purchase requests.</li>
            <li>https://api.tangocard.com/Version2/[method]</li>
        </ul>
    </dd>
</dl>

<a name="tango_card_service_api_security"></a>
## Tango Card Service API Security ##

Requests are secure HTTP POST using SSL.

All calls are made via <a href="http://technet.microsoft.com/en-us/library/cc784450(v=ws.10).aspx">"TLS/SSL"</a> and authentication is handled via client-certificates. A user account will be issued a certificate that must be used to sign every request. If it is desired, the vendor may supply their own certificate as long as it comes from a trusted root CA. Vendors may have multiple certificates associated with their account, but the certificates will have to be loaded by TangoCard engineering (for the time being).


<a name="tango_card_api_methods"></a>
# Tango Card API Methods #

<a name="request_getavailablebalance" id="request_getavailablebalance"></a> 
## GetAvailableBalance ##

<dl>
    <dt>Description</dt>
    <dd>Request the available balance to the user whose authentication was supplied.</dd>
    <dt>Inputs</dt>
    <dd>
        <dl>
            <dt>username</dt>
            <dd></dd>
            <dt>password</dt>
            <dd></dd>
        </dl>
    </dd>

    <dt>Outputs</dt>
    <dd>
        <ul>
        <li>availableBalance - integer - The balance available to the user in cents (100 = $1.00).</li>
        </ul>
    </dd>
        <dt>Possible Errors</dt>
        <dd>
        <ul>
            <li>SYS_ERROR</li>
            <li>INV_CREDENTIAL</li>
        </ul>
    </dd>
</dl>
    
<a name="request_purchasecard" id="request_purchasecard"></a>
## PurchaseCard ##

### Description ###

Purchase a single card to be delivered as described.

### Inputs ###

<ul>
<li>cardSku - string - The SKU of the card to purchase.</li>
<li>cardValue - integer - The value of the card to purchase.</li>
<li>tcSend - boolean - Whether Tango Card will send the email to the user.</li>
<li>recipientName - string (length 1 - 255, required if tcSend=true) - The name of the person receiving the card.</li>
<li>recipientEmail - string (length 3 - 255, required if tcSend=true) - The email address of the person receiving the card.</li>
<li>giftMessage - string (length 1 - 255, required if tcSend=true) - A message from the sender of the card to the recipient. May be null, but must exist if tcSend = true.</li>
<li>giftFrom - string (length 1 - 255, required if tcSend=true) - The name of the person sending the card.</li>
</ul>
    

### Outputs ###

<ul>
    <li>referenceOrderId - string - A unique token that we can use to look up the order.</li>
    <li>cardToken - string - A unique token that we can use to look up the card.</li>
    <li>cardNumber - string - The card’s "number".</li>
    <li>cardPin - string - The card’s "pin", may be null.</li>
</ul>

### Possible Errors ###


<ul>
<li>SYS_ERROR</li>
<li>INV_CREDENTIAL</li>
<li>INV_INPUT</li>
<li>INS_INV</li>
<li>INS_FUNDS</li>
</ul> 

<a name="responses" id="responses"></a>
# Responses #
  
All responses are a JSON-encoded object with the format of:

<ul>
<li>"responseType":STRING</li>
<li>"response":OBJECT</li>
</ul>
  
The value of responseType will influence the format of the object in response. For "SUCCESS" cases the object will have properties as outlined in the "Outputs" section for the method. For the other cases the format is as follows:

  
## SYS_ERROR ##

An error happened on our end. The call may may be re-tried, however if the error persists please contact us.

<ul>
<li>errorCode - string - An internal error code that we can use to track down where the error occurred.</li>
</ul>
    

## INV_INPUT ##

One (or more) of the supplied inputs didn’t meet the requirements. The request should be altered before resubmitting.

<ul>
<li>invalid - object - The object’s properties are the name of the invalid field, the value of the property is description of the associated problem.</li>
</ul>
    

## INV_CREDENTIAL ##

The credential was either missing, or something was wrong with it. The request should be altered before resubmitting.

<ul>
<li>message - string - A description of what appeared to be wrong with the supplied credential.</li>
</ul>
    

## INS_INV ##

We don’t have enough available inventory to fulfill the request. The request should be altered before resubmitting.

<ul>
<li>sku - string - The SKU that we couldn’t fulfill.</li>
<li>value - int - The value that we couldn’t fulfill.</li>
</ul>
    

## INS_FUNDS ##

The account associated with the authenticated user doesn’t have enough available balance to cover the cost of the purchase.

<ul>
<li>availableBalance - int - The balance currently available in cents (100 = $1.00).</li>
<li>orderCost - int - The amount the order would cost to complete in cents (100 = $1.00).</li>
</ul>
    
  

