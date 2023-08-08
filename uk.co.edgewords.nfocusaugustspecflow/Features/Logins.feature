Feature: Logins

Scenario Outline: Login with valid username and password
	Given I am on the login page
	When I login using '<username>' and '<password>'
	Then I am logged in successfully
	Examples: 
	| username     | password         |
	| edgewords    | edgewords123     |
	| webdriver    | edgewords123     |
	#| notvaliduser | notvalidPassword |
