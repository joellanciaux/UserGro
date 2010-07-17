Feature: In order to manage nearby groups / events
	As a programmer 
	I want to see everything available

Scenario: Privacy respected
	Given I am a user that allows friends only to view page
	When a nonfriend requests my information
	Then only basic information is returned

	Given I am a user that allows friends only to view page
	When a friend requests my information
	Then my full profile information is displayed

	Given I am a user that requires authentication to be my friend
	When a user requests to be my friend
	Then they are added to awaiting approval
	And not added to friends

	Given I am a user that requires authentication to be my friend
	When a friend requests to be my friend
	Then nothing happens

	Given I am a user that does NOT require authentication to be my friend
	When a user requests to be my friend 
	Then they are added to my friends list

	Given I am a user that does NOT require authentication to be my friend
	When a user requests to be my friend 
	Then nothing happens 

	Given I am a user that is not part of the local .NET group
	When I attempt to join the group
	And the group does not require approval 
	Then it is added to my groups

	Given I am a user that is not part of the local .NET group
	When I attempt to join the group
	And the group DOES require approval
	Then I am added to the groups Awaiting approval
	
	Given I am a user that wants to attend a local day of .NET 
	When I attempt to register for the event
	And there is still room to join the event 
	Then I am added to the event's attendee's 
	And the event is added to my EventsAttending 

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

	Given I am a user logged into the system 
	When I send a message to another user
	And I am not their friend
	And they allow messages to be sent to them from nonfriends
	Then my message is in their inbox

	Given I am a user logged into the system 
	When I send a message to another user
	And I am not their friend
	And they do NOT allow messages to be sent to them from nonfriends
	Then my message is NOT in their inbox

	Given I am a user logged into the system
	When I send a message to another user
	And the user is my friend
	Then my message is in their inbox

	Given I am a user logged into the system
	When I send a message to a non-existant user
	Then I receive an exception

Scenario: Account administration

	Given I am a potential user 
	When I sign up for an account that is available
	Then it is given to me
	
	Given I am a potential user 
	When I sign up for an account that is not available
	Then it will not allow me to have that account 
	
	Given I am an existing user 
	And I change my email address
	And the email address is not associated with another account
	Then the change is set in the system

	Given I am an existing user
	And I change my email address
	And the email address is associated with another user
	Then no change is made
	And an exception is thrown

	Given I am an existing user 
	And I change my RequiresApprovalToBeFriends
	Then the change is set in the system

	Given I am an existing user 
	And I change my profile to be visible to friends only
	Then the change is set in the system 

	Given I am an existing user
	And I change my profile to allow messages from non-friends 
	Then the change is set in the system

	Given I am an existing user
	And I change my name
	Then the change is set in the system
		
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
	
