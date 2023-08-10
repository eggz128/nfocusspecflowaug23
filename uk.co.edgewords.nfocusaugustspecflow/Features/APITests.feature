@API
Feature: APITests
 For checking User Features

Scenario: Check a single user
	When I request user number '1'
	Then I get a '200' response code
	And The user is 'Bob Jones'
