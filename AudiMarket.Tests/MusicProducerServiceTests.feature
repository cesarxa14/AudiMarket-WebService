Feature: MusicProducerServiceTests
As a Developer
I want to add new MusicProducer through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/musicproducers is available
		
    @musicproducer-adding
    Scenario: Add MusicProducer
        When a MusicProducer Post Request is sent
          | Firstname | Lastname | Dni      | User      | Password |
          | Cesar     | Torres   | 72243434 | cesarxa14 | 1234     |
        Then A MusicProducer Response with Status 200 is received
        And A MusicProducer Resource is included in Response Body
          | Id | Firstname | Lastname | Dni      | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | cesarxa14 | 1234     |