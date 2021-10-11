Feature: Daily schedule page
As a user
I want to see the schedule listing for a particular day
So that I know the scheduled programmes
	
	Background:
		Given I am on the programmes homepage
	
	Scenario: This month's calendar link is displayed
		When I select the service Radio 1
		Then I am on service schedule page
		And 'Calendar' links to the monthly schedule page

	Scenario: This week's calendar link is displayed
		When I select the service Radio 1
		Then I am on service schedule page
		And 'This week' links to the weekly schedule page
		
	Scenario: List of scheduled broadcasts is displayed
		When I select the service BBC Two
		Then I am on service schedule page
		And broadcast item links to the broadcast's episode page
		