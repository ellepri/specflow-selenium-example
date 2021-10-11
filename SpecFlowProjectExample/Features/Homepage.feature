Feature: Homepage
As a user
I want to have a brief view of BBC programmes
So that I can choose from the variety of BBC offering

    Background:
        Given I am on the programmes homepage

    Scenario: Titles are displayed
        Then the page title is set in the html header to 'BBC - Programmes'
        And the masthead title is 'Programmes'

    Scenario: Programmes counter is displayed
        Then the total number of programmes in PIPs is displayed
        And it is followed by the text 'total programmes & groups'

    Scenario: Intro static text is displayed
        Then the intro text is displayed

    Scenario: Services list headings are displayed
        Then the below service type headings are displayed
          | service_type   |
          | TV             |
          | National Radio |
          | Nations Radio  |
          | Local Radio    |
      
    Scenario Outline: Service links to schedule pages
        When I select the service <name>
        Then I go to the schedule page <url>
        And I am on service schedule page

        Examples: of services and their schedule pages
          | name    | url                 |
          | BBC One | /schedules/p00fzl6p |
          | BBC Two | /schedules/p00fzl97 |
          