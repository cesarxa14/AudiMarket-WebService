Feature: ReviewServiceTests
As a Developer
I want to add new Review through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/reviews is available
        And A MusicProducer for Review is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | 0001-01-01T00:00:00 | cesarxa14 | 1234     |
        And A VideoProducer for Review is already stored
          | Id | Firstname | Lastname | Dni      | Entrydate           | User      | Password |
          | 1  | Jorge     | Navarro  | 74582556 | 0001-01-01T00:00:00 | jorgevill | asdf     |
    
    @review-adding
    Scenario: Add Review
        When a Review Post Request is sent
          | Qualification | Description          | PublicationDate     | VideoProducerId | MusicProducerId |
          | 4             | Hizo un buen trabajo | 0001-01-01T00:00:00 | 1               | 1               |
        Then A Review Response with Status 200 is received
        And A Review Resource is included in Response Body
          | Id | Qualification | Description          | PublicationDate     | VideoProducerId | MusicProducerId |
          | 1  | 4             | Hizo un buen trabajo | 0001-01-01T00:00:00 | 1               | 1               |
    
    #@review-invalid-musicproducer
    #Scenario: Add Review with Invalid MusicProducer
    #    When a Post Request is sent
    #      | Qualification | Description          | PublicationDate | VideoProducerId | MusicProducerId |
    #      | 4             | Hizo un buen trabajo | 2021-07-05      | 1               | 1               |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Music Producer" is included in Response Body
        
    #@review-invalid-videoproducer
    #Scenario: Add Review with Invalid VideoProducer
    #    When a Post Request is sent
    #      | Qualification | Description          | PublicationDate | VideoProducerId | MusicProducerId |
    #      | 4             | Hizo un buen trabajo | 2021-07-05      | 1               | 1               |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Video Producer" is included in Response Body
        