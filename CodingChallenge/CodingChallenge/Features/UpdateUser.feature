Feature: UpdateUser
	


Scenario: Update User
	Given I input name "Amy"
	Given I input role "QA"
	When I send create user request
	When Validate user is created
	When User is updated with "Tom"
	Then Response code is 200


