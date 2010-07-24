Feature: Join Event
	In order to attend events
	As a user	
	I want to register for events

Scenario: User join event
	Given I want to go to the MAGIC SHOW event
	And the event is not moderated
	And there is no room left
	When I attempt to register for the event
	Then I am NOT added to the event's attendees 
	And the event is NOT added to my EventsAttending 

	Given I want to go to the MAGIC SHOW event
	And the event is not moderated
	And there is room left
	When I attempt to register for the event
	Then I am added to the event's attendees 
	And the event is added to my EventsAttending 

	Given I want to go to the MAGIC SHOW event
	And the event is moderated
	And there is no room left
	When I attempt to register for the event
	Then I am NOT added to the event's attendees 
	And the event is NOT added to my EventsAttending 

	Given I want to go to the MAGIC SHOW event
	And the event is moderated
	And there is room left
	When I attempt to register for the event
	Then I am added to the event's awaiting approval
	And the event is NOT added to my EventsAttending
