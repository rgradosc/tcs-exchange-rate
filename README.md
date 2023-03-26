# TCS Exchange Rates API 

The API allows you to apply the exchange rate to an amount, for which you need to indicate the source currency, the amount to convert and the target currency and returns a new amount applying the exchange rate for those currencies.

## Docker with Linux

The API contains a dockerfile, which allows you to create the container to deploy the solution locally on port 8080.

## Postman Docs

The project contains a json file containing the Postman API documentation, which contains the exposed resources and usage examples. The endpoints of the resources are:

* Authentication
  * POST -> /api/Users/Authenticate
* Symbols
  * GET -> /api/v1/Symbols
* Exchange Rates
  * GET -> /api/v1/ExchangeRates/convert?Base={base}&Target={target}&Amount={amount}
  * PUT -> /api/v1/ExchangeRates
  
*For more information, please review the documentation file using postman.*
