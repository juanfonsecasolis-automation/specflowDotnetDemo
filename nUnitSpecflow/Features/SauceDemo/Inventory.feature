@uiTest
Feature: Inventory

User can see and interact with the inventory

@regression
Scenario: User is able to see the inventory
	Given user logs in using valid credentials
	Then the inventory page is displayed
	And only six items are rendered

@regression
Scenario: User can arrange inventory items by price from low to high
	Given user logs in using valid credentials
	When user selects "Price (low to high)" in the filter dropdown
	Then inventory items are ordered from price low to high

@regression
Scenario: Product description is displayed
	Given user logs in using valid credentials
	When the inventory page is displayed
	Then the "Sauce Labs Backpack" description is displayed


