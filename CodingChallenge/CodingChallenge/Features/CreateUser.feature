Feature: CreateUser
	


Scenario: Add User
	Given I input name "Amy"
	And I input role "QA"
	When I send create user request
	Then Validate user is created


