Feature: VoucherServiceTests
As a Developer
I want to add new Voucher through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/vouchers is available
        And A PayMethod for Voucher is already stored
          | IdPayMethod | Name    | Description                |
          | 1           | Pos Visa| Método de pago inalámbrico |
        And A Contract for Voucher is already stored
          | Id | Content                 | VideoProducerId | MusicProducerId |
          | 1  | Contrato para noviembre | 1               | 1               |
    
    #@voucher-adding
    #Scenario: Add Voucher
    #    When a Voucher Post Request is sent
    #      | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    #    Then A Voucher Response with Status 200 is received
    #    And A Voucher Resource is included in Response Body
    #      | Id | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | 1  | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    
    #@voucher-invalid-paymethod
    #Scenario: Add Voucher with Invalid MusicProducer
    #    When a Post Request is sent
    #      | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    #    Then A Response with Status 400 is received
    #    And a Voucher of "Invalid Music Producer" is included in Response Body
        
    #@voucher-invalid-contract
    #Scenario: Add Voucher with Invalid VideoProducer
    #    When a Post Request is sent
    #      | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    #    Then A Response with Status 400 is received
    #    And a Voucher of "Invalid Video Producer" is included in Response Body
        