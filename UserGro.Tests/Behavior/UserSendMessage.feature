Feature: Message
	In order to communicated with other users
	As a site user
	I want to be able to send messages 

Scenario: User Send Message

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

