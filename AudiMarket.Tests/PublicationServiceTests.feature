Feature: PublicationServiceTests
As a Developer
I want to add new Publication through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/publications is available
        And A MusicProducer for Publication is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | 0001-01-01T00:00:00 | cesarxa14 | 1234     |
		
    @publication-adding
    Scenario: Add Publication
        When a Publication Post Request is sent
          | Description         | PublicationDate     | MusicProducerId |
          | Soy experto en rock | 2021-11-23T23:44:21 | 1               |
        Then A Publication Response with Status 200 is received
        And A Publication Resource is included in Response Body
          | Id | Description         | PublicationDate     | MusicProducerId |
          | 1  | Soy experto en rock | 2021-11-23T23:44:21 | 1               |
  	
    #@publication-invalid-musicproducer
    #Scenario: Add Publication with Invalid MusicProducer
    #    When a Post Request is sent
    #      | Description         | PublicationDate     | MusicProducerId   |
    #      | Soy experto en rock | 2021-11-23T23:44:21 | 900               |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Music Producer" is included in Response Body
        