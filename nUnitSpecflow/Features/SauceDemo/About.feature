@uiTest
Feature: About

@regression
Scenario: User can access the about page
	Given user logs in using valid credentials
	And user starts intercepting network traffic
	When user selects "About" in the hamburger menu
	Then user request "https://saucelabs.com/" completes with status "200"
