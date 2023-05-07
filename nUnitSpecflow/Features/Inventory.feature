Feature: Inventory

User can see and interact with the inventory

@regression
Scenario: User is able to see the inventory
	Given user opens the login page
	When user logins with username "standard_user" and password "secret_sauce"
	Then the inventory page is displayed
	And only six items are rendered

@regression
Scenario: User can arrange inventory items by price from low to high
	Given user opens the login page
	When user logins with username "standard_user" and password "secret_sauce"
	And user selects "Price (low to high)" in the filter dropdown
	Then inventory items are ordered from low to high
