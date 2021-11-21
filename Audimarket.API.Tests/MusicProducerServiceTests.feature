Feature: MusicProducerServiceTests
	As a developer
	I want to add new MusicProducer through API
	So that I can be available for applications


	Background: 
		Given the endpoint http://localhost:44311/api/v1/musicproducers
		

	@music-producer-adding
	Scenario: Add music producer
		When a Music Producer Request is sent
		| Firstname | Lastname | Dni   | Entrydate  | User    | Password |
		| Jorge     | Perez    | 25555 | 15/10/2021 | cesarxa | 1234     |
		Then A response with Status 200 is received
		And A music producer resource is included in Response body
		| Firstname | Lastname | Dni   | Entrydate  | User    | Password |
		| Jorge     | Perez    | 25555 | 15/10/2021 | cesarxa | 1234     |