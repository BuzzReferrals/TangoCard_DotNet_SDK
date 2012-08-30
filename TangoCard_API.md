<h1>Tango Card Integration Solutions</h1>
<h3>Digital gift cards in minutes</h3>
===

# Table of Contents #
<ul>
    <li><a href="#introduction">Introduction</a>
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

All calls are made via TLS/SSL and authentication is handled via client-certificates. A user account will be issued a certificate that must be used to sign every request. If it is desired, the vendor may supply their own certificate as long as it comes from a trusted root CA. Vendors may have multiple certificates associated with their account, but the certificates will have to be loaded by TangoCard engineering (for the time being).

Testing (integration) URL format is https://int.tangocard.com/ThirdParty/[method] where [method] is to be replaced with one of the methods below.

Production URL format is https://api.tangocard.com/ThirdParty/[method] where [method] is to be replaced with one of the methods below.

<a name="request_methods"></a>
# Requests #
All requests are via JSON-encoded objects as the payload of a HTTP POST call on a specified method. As an example, if the input listed below was ‘sku’ then the POST body might look like:

```json
{"sku":"tango-card"}
```

Note, however that since this is an HTTP POST that this should be “percent-encoded”, as normal, so the actual body might actually look more like:

```text
%7B%22sku%22%3A%22tango-card%22%7D
```

<a name="request_getavailablebalance" id="request_getavailablebalance"></a> 
## GetAvailableBalance ##

  <dl>
    <dt>Description:</dt>

    <dd>Shows the available balance to the user whose authentication was supplied.</dd>

    <dt>Inputs:</dt>

    <dd>None</dd>

    <dt>Outputs:</dt>

    <dd>
      <ul>
        <li>availableBalance - integer - The balance available to the user in cents (100
        = $1.00).</li>
      </ul>
    </dd>

    <dt>Possible Errors:</dt>

    <dd>
      <ul>
        <li>SYS_ERROR</li>

        <li>INV_CREDENTIAL</li>
      </ul>
    </dd>
  </dl>

<a name="request_getavailablecards" id="request_getavailablecards"></a> 
## GetAvailableCards ##

  <dl>
    <dt>Description:</dt>

    <dd>Shows a list of cards that authenticated user is allowed to purchase.</dd>

    <dt>Inputs:</dt>

    <dd>None</dd>

    <dt>Outputs:</dt>

    <dd>
      <ul>
        <li>array of:

          <ul>
            <li>description - A human-readable name for the card (e.g.
            &acirc;&euro;&oelig;Tango Card&acirc;&euro;).</li>

            <li>sku - A top-level SKU for the card.</li>
          </ul>
        </li>
      </ul>
    </dd>

    <dt>Possible Errors:</dt>
    <dd>
        <ul>
            <li>SYS_ERROR</li>

            <li>INV_CREDENTIAL</li> 
        </ul>    
    </dd>
    </dl>
<a name="request_getcardinventory" id= "request_getcardinventory"></a> 
## GetCardInventory ##

  <dl>
    <dt>Description:</dt>

    <dd>Find the available denominations for a given SKU.</dd>

    <dt>Inputs:</dt>

    <dd>
      <ul>
        <li>sku - string - A SKU as supplied by GetAvailableCards.</li>
      </ul>
    </dd>

    <dt>Outputs:</dt>

    <dd>
      <ul>
        <li>availableValues - array of integers - Each integer denotes an increment that
        the card can be purchased in. -1 (negative one) denotes that the card is, so
        called, variable. This means that it&acirc;&euro;&trade;s available in
        (theoretically) any denomination.</li>
      </ul>
    </dd>

    <dt>Possible Errors:</dt>

    <dd>
      <ul>
        <li>SYS_ERROR</li>

        <li>INV_CREDENTIAL</li>

        <li>INV_INPUT</li>
      </ul>
    </dd>
  </dl>
  
  <a name="request_purchasecard" id="request_purchasecard"></a>
  ## PurchaseCard ##

  <dl>
    <dt>Description:</dt>

    <dd>Purchase a single card to be delivered as described.</dd>

    <dt>Inputs:</dt>

    <dd>
      <ul>
        <li>cardSku - string - The SKU of the card to purchase.</li>

        <li>CardValue - integer - The value of the card to purchase.</li>

        <li>tcSend - boolean - Whether Tango Card will send the email to the user.</li>

        <li>recipientName - string (length 1 - 255, required if tcSend=true) - The name of the person receiving the card. Recipient</li>

        <li>Email - string (length 3 - 255, required if tcSend=true) - The email address of the person receiving the card.</li>

        <li>giftMessage - string (length 1 - 255, required if tcSend=true) - A message from the sender of the card to the recipient. May be null, but must exist if tcSend = true.</li>

        <li>giftFrom - string (length 1 - 255, required if tcSend=true) - The name of the person sending the card.</li>
      </ul>
    </dd>

    <dt>Outputs:</dt>

    <dd>
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

            <li>cardNumber - string - The card&acirc;&euro;&trade;s &acirc;&euro;&oelig;number&acirc;&euro;.</li>

            <li>cardPin - string - The card&acirc;&euro;&trade;s &acirc;&euro;&oelig;pin&acirc;&euro;, may be null.</li>
          </ul>
        </li>
      </ul>
    </dd>

    <dt>Possible Errors:</dt>

    <dd>
      <ul>
        <li>SYS_ERROR</li>

        <li>INV_CREDENTIAL</li>

        <li>INV_INPUT</li>

        <li>INS_INV</li>

        <li>INS_FUNDS</li>
      </ul>
    </dd>
  </dl>
  
  <a name="responses" id="responses"></a>
  # Responses # 
  
  <p>All responses are a JSON-encoded object with the format of:</p>

  <ul>
    <li>&acirc;&euro;&oelig;responseType&acirc;&euro;:STRING</li>

    <li>&acirc;&euro;&oelig;response&acirc;&euro;:OBJECT</li>
  </ul>
  
    <p>The value of responseType will influence the format of the object in response. For &acirc;&euro;&oelig;SUCCESS&acirc;&euro; cases the object will have properties as outlined in the &acirc;&euro;&oelig;Outputs&acirc;&euro; section for the method. For the other cases the format is as follows:</p>

  <dl>
    <dt>SYS_ERROR</dt>

    <dd>
      <p>An error happened on our end. The call may may be re-tried, however if the error
      persists please contact us.</p>

      <ul>
        <li>errorCode - string - An internal error code that we can use to track down
        where the error occurred.</li>
      </ul>
    </dd>

    <dt>INV_INPUT</dt>

    <dd>
      <p>One (or more) of the supplied inputs didn&acirc;&euro;&trade;t meet the
      requirements. The request should be altered before resubmitting.</p>

      <ul>
        <li>invalid - object - The object&acirc;&euro;&trade;s properties are the name of
        the invalid field, the value of the property is description of the associated
        problem.</li>
      </ul>
    </dd>

    <dt>INV_CREDENTIAL</dt>

    <dd>
      <p>The credential was either missing, or something was wrong with it. The request
      should be altered before resubmitting.</p>

      <ul>
        <li>message - string - A description of what appeared to be wrong with the
        supplied credential.</li>
      </ul>
    </dd>

    <dt>INS_INV</dt>

    <dd>
      <p>We don&acirc;&euro;&trade;t have enough available inventory to fulfill the request.
      The request should be altered before resubmitting.</p>

      <ul>
        <li>sku - string - The SKU that we couldn&acirc;&euro;&trade;t fulfill.</li>

        <li>value - int - The value that we couldn&acirc;&euro;&trade;t fulfill.</li>
      </ul>
    </dd>

    <dt>INS_FUNDS</dt>

    <dt>The account associated with the authenticated user doesn&acirc;&euro;&trade;t
    have enough available balance to cover the cost of the purchase.</dt>

    <dd>
      <ul>
        <li>availableBalance - int - The balance currently available in cents (100 =
        $1.00).</li>

        <li>orderCost - int &acirc;&euro;&ldquo; The amount the order would cost to
        complete in cents (100 = $1.00).</li>
      </ul>
    </dd>
  </dl>

<p>Update 3.21.12 | To learn more about Tango Card integration solutions, call 1.877.55.TANGO</p>