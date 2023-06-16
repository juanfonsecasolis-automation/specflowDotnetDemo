Feature: About

@tag1
Scenario: User can access the about page
	Given user logs in using valid credentials
	When user selects "About" in the hamburger menu
	Then the saucelabs webpage is displayed
