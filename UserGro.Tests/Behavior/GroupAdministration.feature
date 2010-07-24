Feature: Group Administration
	In order to maintain groups	
	As a user
	I want to administer any groups I create

Scenario: Group administration

	Given I am an existing user
	And I am a group admin
	When I need a speaker for a new event
	Then I can push a notification that I am looking for speakers for that event

	Given I am an existing user
	And I am a group admin 
	When I try to create a new event for the group 
	Then the event is added to my events I'm attending
	And the group is added to events I'm admin
	And it is added to the other group's admins events admin