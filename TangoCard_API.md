<h1>Tango Card Integration Solutions</h1>
<h3>Digital gift cards in minutes</h3>
===

# Table of Contents #
<ul>
<li><a href="#introduction">Introduction</a>
</li>
<li><a href="#overview">Overview</a>
</li>
<li><a href="#request_methods">Requests</a>
<ul>
<li><a href="#request_getavailablebalance">GetAvailableBalance</a></li>
<li><a href="#request_getavailablecards">GetAvailableCards</a></li>
<li><a href="#request_getcardinventory">GetCardInventory</a></li>
<li><a href="#request_purchasecard">PurchaseCard</a></li>
</ul>
</li>
<li><a href="#responses">Responses</a>
</li>
</ul>

<a name="introduction"></a>
# Introduction #

Tango Card's API is flexible, secure, and straightforward. It allows any server to purchase gift cards and is intended for users requiring high volume transactions and processes. While simple enough that developers can start integrating within 15 minutes, it is robust enough so developers don't have to deal with JSON or setting up secure network connections with our server.

### Contact Us ###

To learn more about Tango Card integration solutions, call 1.877.55.TANGO

<a name="overview"></a>
# Overview #
All calls are made via <a href="http://technet.microsoft.com/en-us/library/cc784450(v=ws.10).aspx">"TLS/SSL"</a> and authentication is handled via client-certificates. A user account will be issued a certificate that must be used to sign every request. If it is desired, the vendor may supply their own certificate as long as it comes from a trusted root CA. Vendors may have multiple certificates associated with their account, but the certificates will have to be loaded by TangoCard engineering (for the time being).

Testing (integration) URL format is https://int.tangocard.com/ThirdParty/[method] where [method] is to be replaced with one of the methods below.

Production URL format is https://api.tangocard.com/ThirdParty/[method] where [method] is to be replaced with one of the methods below.

<a name="request_methods"></a>
# Requests #
All requests are via JSON-encoded objects as the payload of a HTTP POST call on a specified method. As an example, if the input listed below was "sku" then the POST body might look like:

```json
{"sku" : "tango-card"}
```

Note, however that since this is an HTTP POST that this should be <a href="http://en.wikipedia.org/wiki/Percent-encoding">"percent-encoded"</a>, as normal, so the actual body might actually look more like:

```text
%7B%22sku%22%3A%22tango-card%22%7D
```

<a name="request_getavailablebalance" id="request_getavailablebalance"></a> 
## GetAvailableBalance ##

  
### Description ###

Shows the available balance to the user whose authentication was supplied.

### Inputs ###

None

### Outputs ###


<ul>
<li>availableBalance - integer - The balance available to the user in cents (100 = $1.00).</li>
</ul>
    

### Possible Errors ###


<ul>
<li>SYS_ERROR</li>

<li>INV_CREDENTIAL</li>
</ul>
    
  

<a name="request_getavailablecards" id="request_getavailablecards"></a> 
## GetAvailableCards ##

  
### Description ###

Shows a list of cards that authenticated user is allowed to purchase.

### Inputs ###

None

### Outputs ###


<ul>
<li>array of:
<ul>
<li>description - A human-readable name for the card (e.g. "Tango Card").</li>

<li>sku - A top-level SKU for the card.</li>
</ul>
</li>
</ul>
    

### Possible Errors ###

<ul>
<li>SYS_ERROR</li>

<li>INV_CREDENTIAL</li> 
</ul>    
    
    
<a name="request_getcardinventory" id= "request_getcardinventory"></a> 
## GetCardInventory ##

### Description ###

Find the available denominations for a given SKU.

### Inputs ###

<ul>
<li>sku - string - A SKU as supplied by GetAvailableCards.</li>
</ul>
    

### Outputs ###


<ul>
<li>availableValues - array of integers - Each integer denotes an increment that
        the card can be purchased in. -1 (negative one) denotes that the card is, so
        called, variable. This means that it’s available in
        (theoretically) any denomination.</li>
</ul>
    

### Possible Errors ###


<ul>
<li>SYS_ERROR</li>

<li>INV_CREDENTIAL</li>

<li>INV_INPUT</li>
</ul>
    
  
  
<a name="request_purchasecard" id="request_purchasecard"></a>
  ## PurchaseCard ##

  
### Description ###

Purchase a single card to be delivered as described.

### Inputs ###


<ul>
<li>cardSku - string - The SKU of the card to purchase.</li>

<li>CardValue - integer - The value of the card to purchase.</li>

<li>tcSend - boolean - Whether Tango Card will send the email to the user.</li>

<li>recipientName - string (length 1 - 255, required if tcSend=true) - The name of the person receiving the card. Recipient</li>

<li>Email - string (length 3 - 255, required if tcSend=true) - The email address of the person receiving the card.</li>

<li>giftMessage - string (length 1 - 255, required if tcSend=true) - A message from the sender of the card to the recipient. May be null, but must exist if tcSend = true.</li>

<li>giftFrom - string (length 1 - 255, required if tcSend=true) - The name of the person sending the card.</li>
</ul>
    

### Outputs ###


<ul>
<li>If tcSend was set to true:

<ul>
<li>referenceOrderId - string - A unique token that we can use to look up the order.</li>

<li>cardToken - string - A unique token that we can use to look up the card.</li>
  </ul>
    </li>

<li>If tcSend was set to false:

<ul>
<li>referenceOrderId - string - A unique token that we can use to look up the order.</li>

<li>cardToken - string - A unique token that we can use to look up the card.</li>

<li>cardNumber - string - The card’s "number".</li>

<li>cardPin - string - The card’s "pin", may be null.</li>
  </ul>
    </li>
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

  
### SYS_ERROR ###


  An error happened on our end. The call may may be re-tried, however if the error persists please contact us.

<ul>
<li>errorCode - string - An internal error code that we can use to track down where the error occurred.</li>
</ul>
    

### INV_INPUT ###


  One (or more) of the supplied inputs didn’t meet the requirements. The request should be altered before resubmitting.

<ul>
<li>invalid - object - The object’s properties are the name of the invalid field, the value of the property is description of the associated problem.</li>
</ul>
    

### INV_CREDENTIAL ###


  The credential was either missing, or something was wrong with it. The request should be altered before resubmitting.

<ul>
<li>message - string - A description of what appeared to be wrong with the supplied credential.</li>
</ul>
    

### INS_INV ###


  We don’t have enough available inventory to fulfill the request.
      The request should be altered before resubmitting.

<ul>
<li>sku - string - The SKU that we couldn’t fulfill.</li>

<li>value - int - The value that we couldn’t fulfill.</li>
</ul>
    

### INS_FUNDS ###

The account associated with the authenticated user doesn’t have enough available balance to cover the cost of the purchase.


<ul>
<li>availableBalance - int - The balance currently available in cents (100 = $1.00).</li>

<li>orderCost - int - The amount the order would cost to complete in cents (100 = $1.00).</li>
</ul>
    
  

