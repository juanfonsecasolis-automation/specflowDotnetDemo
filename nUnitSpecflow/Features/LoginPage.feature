Feature: LoginPage

Opens the Login Page

@regression
Scenario: User is able to login using valid credentials
	Given user opens the login page
	When user logins with username "<username>" and password "<password>"
	Then the inventory page is displayed

	Examples: 
	| username      | password       |
	| standard_user | secret_sauce   |

@regression
Scenario: The inventory page is arranged as expected
	Given user opens the login page
	When user logins with username "standard_user" and password "secret_sauce"
	Then the inventory page is displayed
	And only six items are rendered