Feature: MusicProducerServiceTests
	As a developer
	I want to add new MusicProducer through API
	So that I can be available for applications


Background: 
	Given the endpoint http://localhost:44311/api/v1/musicproducers

@music-producer-adding
Scenario: Add music producer
	Given Music Producer adding
	When a Post Request is sent
	| Firstname | Lastname |
	| Jorge     | Perez    |
	Then A response with Status 200 is received
	And A publication resource is included in Response body
	| Firstname | Lastname |
	| Raul     | Medina    |