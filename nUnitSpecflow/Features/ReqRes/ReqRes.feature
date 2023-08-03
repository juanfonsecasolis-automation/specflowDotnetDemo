Feature: ReqRes

Test for testing an API to administrate users

@regression
Scenario: Verify pagination returns the same number of items specified on the "per_page" property (GET)
	Given user initializes the ReqRes connection for "ListUsers"
	When user requests a list of "<resultsPerPage>" users
	Then only "<resultsPerPage>" users are returned

	Examples: 
	| resultsPerPage |
	| 5              |
