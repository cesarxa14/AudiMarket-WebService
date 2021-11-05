Feature: PublicationServiceTests
	As a developer
	I want to add new Publication through API
	So that I can be available for applications

Background: 
	Given the endpoint http://localhost:44311/api/v1/publications

@publication-adding
Scenario: Add publication
	When a Post Request is sent
	| Description |
	| Hola        |
	Then a response with Status 200 is received
	And a publication resource is included in Response body
	| Id | Description |
	| 2  | Chau        |

