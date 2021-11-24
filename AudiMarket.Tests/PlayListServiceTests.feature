Feature: PlayListServiceTests
As a Developer
I want to add new PlayList through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/playlists is available
        And A MusicProducer for PlayList is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | 0001-01-01T00:00:00 | cesarxa14 | 1234     |
    
    @playlist-adding
    Scenario: Add PlayList
        When a PlayList Post Request is sent
          | Description         | AddedDate | MusicProducerId |
          | Soy experto en rock | 2021-11-23T23:44:21 | 1               |
        Then A PlayList Response with Status 200 is received
        And A PlayList Resource is included in Response Body
          | Id | Description         | AddedDate           | MusicProducerId |
          | 1  | Soy experto en rock | 2021-11-23T23:44:21 | 1               |
    
    #@playlist-invalid-musicproducer
    #Scenario: Add PlayList with Invalid MusicProducer
    #    When a Post Request is sent
    #      | Description         | AddedDate           | MusicProducerId   |
    #      | música de octubre   | 2021-11-23T23:44:21 | 900               |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Music Producer" is included in Response Body