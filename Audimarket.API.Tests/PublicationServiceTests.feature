Feature: PublicationServiceTests
	As a developer
	I want to add new Publication through API
	So that I can be available for applications

Background: 
	Given the endpoint http://localhost:44311/api/v1/publications

@publication-adding
Scenario: Add publication
	Given the first number is 50
	And the second number is 70
	When a Post Request is sent
	| Description | MusicProducerId |
	| Hola        | 1               |
	Then A response with Status 200 is received
	And A publication resource is included in Response body
	| Id | Description | MusicProducerId |
	| 2  | Chau        | 1               |

