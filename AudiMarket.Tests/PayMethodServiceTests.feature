Feature: PayMethodServiceTests
As a Developer
I want to add new PayMethod through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/paymethods is available
    
    @paymethod-adding
    Scenario: Add PayMethod
        When a PayMethod Post Request is sent
          | Name     | Description                |
          | POS Visa | Método de pago inalámbrico |
        Then A PayMethod Response with Status 200 is received
        And A PayMethod Resource is included in Response Body
          | Id | Name     | Description                |
          | 1  | POS Visa | Método de pago inalámbrico |