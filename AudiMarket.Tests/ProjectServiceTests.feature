Feature: ProjectServiceTests
As a Developer
I want to add new Project through API
So that I can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/projects is available
        And A PlayList for Project is already stored
          | Id | Description         | AddedDate    | MusicProducerId |
          | 1  | música de enero     | 2021-07-05   | 1               |
    
    @project-adding
    Scenario: Add Project
        When a Project Post Request is sent
          | Name  | Description | AddedDate           | PlayListId |
          | Cover | Cover Queen | 2021-11-23T23:44:21 | 1          |
        Then A Project Response with Status 200 is received
        And A Project Resource is included in Response Body
          | Id | Name  | Description | AddedDate           | PlayListId |
          | 1  | Cover | Cover Queen | 2021-11-23T23:44:21 | 1          |
    
    #@project-invalid-playlist
    #Scenario: Add Project with Invalid PlayList
    #    When a Post Request is sent
    #      | Name  | Description | AddedDate           | PlayListId |
    #      | Cover | Cover Queen | 2021-11-23T23:44:21 | X          |
    #    Then A Response with Status 400 is received
    #    And a Message of "Invalid Play List" is included in Response Body