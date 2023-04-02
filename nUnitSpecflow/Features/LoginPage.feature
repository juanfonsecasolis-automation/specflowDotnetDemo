Feature: LoginPage

Opens the Login Page

@regression
Scenario: User is able to login using valid credentials
	Given user opens the login page
	When user logins with username "<username>" and password "<password>"
	Then the inventory page is displayed

	Examples: 
	| username      | password         |
	| standard_user | secret_sauce     |

@regression
Scenario: User is able to see the inventory
	Given user opens the login page
	When user logins with username "standard_user" and password "secret_sauce"
	Then the inventory page is displayed
	And only six items are rendered

@regression @ignore("123,456")
Scenario: User can arrange inventory items by price from low to high
	Given user opens the login page
	When user logins with username "standard_user" and password "secret_sauce"
	And user selects "Price (low to high)" in the filter dropdown
	Then inventory items are ordered from low to high