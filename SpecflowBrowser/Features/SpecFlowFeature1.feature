Feature: SpecFlowFeature1
	Login to the web site
	Search the specified products on the website
	Log out the web site



Scenario: 01 Successful Login with Valid Credentials
	Given User is at the Home Page
	And Navigate to LogIn Page
	When User enter username and password
	| username   | password |
	| test_spec1 | 3hKmEiWd)zDZ#hJO |
	And Click on the LogIn button
	Then Successful LogIN message should display
	When User enter search text to search input
	| searchtext |
	| Mouse      |
	Then Successful search result items should display
	When User LogOut from the Application	
	Then Successful LogOut message should display
