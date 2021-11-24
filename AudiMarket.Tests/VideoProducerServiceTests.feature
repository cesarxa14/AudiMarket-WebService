Feature: VideoProducerServiceTests
As a Developer
I want to add new VideoProducer through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/videoproducers is available
    
    @videoproducer-adding
    Scenario: Add VideoProducer
        When a VideoProducer Post Request is sent
          | Firstname | Lastname | Dni      | User      | Password |
          | Cesar     | Torres   | 72243434 | cesarxa14 | 1234     |
        Then A VideoProducer Response with Status 200 is received
        And A VideoProducer Resource is included in Response Body
          | Id | Firstname | Lastname | Dni      | User      | Password |
          | 1  | Cesar     | Torres   | 72243434 | cesarxa14 | 1234     |