Feature: Event admin 
	In order to maintain events
	As a user	
	I want to be able to create and modfiy events

Scenario: Event administration
	Given I am a user that wants to start an event 
	When I create an event 
	Then it gets added to my events admin 
	And it gets added to my events attending

	Given I am a user that is an event admin 
	When I remove an attendee 
	Then they are no longer in the list of those coming 

	Given I am a user that is an event admin
	When I promote another user to admin the event
	Then they are promoted to admin

