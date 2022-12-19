Feature: LoginPage

Opens the Login Page

@regression
Scenario: User is able to login using valid credentials
	Given user opens the login page
	When user logins with username "<username>" and password "<password>"
	Then the inventory page is displayed

	Examples: 
	| username      | password     |
	| standard_user | secret_sauce |
