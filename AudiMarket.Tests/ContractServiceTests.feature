Feature: ContractServiceTests
As a Developer
I want to add new Contract through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/contracts is available
        And A MusicProducer for Contract is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | 0001-01-01T00:00:00 | cesarxa14 | 1234     |
        And A VideoProducer for Contract is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Jorge     | Navarro  | 74582556 | 0001-01-01T00:00:00 | jorgevill | asdf     |
		
    @contract-adding
    Scenario: Add Contract
        When a Contract Post Request is sent
          | Content                 | VideoProducerId     | MusicProducerId |
          | Contrato para noviembre | 1                   | 1               |
        Then A Contract Response with Status 200 is received
        And A Contract Resource is included in Response Body
          | Id | Content                 | VideoProducerId | MusicProducerId |
          | 1  | Contrato para noviembre | 1               | 1               |
  	
    #@contract-invalid-musicproducer
    #Scenario: Add Contract with Invalid MusicProducer
    #    When a Post Request is sent
    #      | Content                 | VideoProducerId     | MusicProducerId |
    #      | Contrato para noviembre | 1                   | 1               |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Music Producer" is included in Response Body
        
    #@contract-invalid-videoproducer
    #Scenario: Add Contract with Invalid VideoProducer
    #    When a Post Request is sent
    #      | Description             | VideoProducerId     | MusicProducerId   |
    #      | Contrato para noviembre | 900                 | 1                 |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Video Producer" is included in Response Body
        