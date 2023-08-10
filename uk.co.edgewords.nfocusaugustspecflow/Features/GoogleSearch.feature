@RunMe @GUI
Feature: Google Search


Scenario: Search Google for edgewords
	Given I am at the Google homepage
	When I search for 'edgewords'
	Then 'edgewords' is the top result


@RunMeToo @AndMe @ignore @RunTag @IgnoreTag
Scenario Outline: Search Google for stuff
	Given i Am at google
	When I search for '<searchTerm>'
	Then '<searchTerm>' is the top result
	Examples: 
	| searchTerm |
	| edgewords  |
	| bbc        |


@RunMeToo
Scenario: Check edgewords description and url
	Given I am on the Google homepage
	When I search for 'edgewords'
	Then I should see in the results
	| url                                 | description                                                                                                                                        |
	| https://www.edgewordstraining.co.uk | Edgewords: The Training Specialists for Automated Software Testing ... With over a decade of delivering training to Software Testers, Edgewords is |
	| https://twitter.com › edgewords     | https://edgewordstraining.co.uk Edgewords delivers training courses in automated testing tools; Ranorex, Selenium, Appium, Cucumber, SpecFlow.     |