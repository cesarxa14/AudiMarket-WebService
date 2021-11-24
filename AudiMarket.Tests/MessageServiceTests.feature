Feature: MessageServiceTests
As a Developer
I want to add new Message through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/messages is available
        And A MusicProducer for Message is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | 0001-01-01T00:00:00 | cesarxa14 | 1234     |
        And A VideoProducer for Message is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Jorge     | Navarro  | 74582556 | 0001-01-01T00:00:00 | jorgevill | asdf     |
    
    #@message-adding
    #Scenario: Add Message
    #    When a Message Post Request is sent
    #      | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    #    Then A Message Response with Status 200 is received
    #    And A Message Resource is included in Response Body
    #      | Id | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | 1  | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    
    #@message-invalid-musicproducer
    #Scenario: Add Message with Invalid MusicProducer
    #    When a Post Request is sent
    #      | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Music Producer" is included in Response Body
        
    #@message-invalid-videoproducer
    #Scenario: Add Message with Invalid VideoProducer
    #    When a Post Request is sent
    #      | Content                 | IdvProducer     | dmProducer | Create Date |
    #      | Contrato para noviembre | 1               | 1          | 2021-11-24  |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Video Producer" is included in Response Body
        