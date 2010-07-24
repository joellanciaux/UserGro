Feature: Message
	In order to communicated with other users
	As a site user
	I want to be able to send messages 

Scenario: User Send Message

	Given I am a user logged into the system 
	And I am not friends with a certain user
	And they allow messages to be sent from nonfriends
	When I send a message to this user
	Then my message is in their inbox
	And is in my sent messages 

	Given I am a user logged into the system 
	And I am not friends with a certain user
	And they do NOT allow messages to be sent from nonfriends
	When I send a message to this user
	Then my message is NOT in their inbox
	And is NOT in my sent messages 

	Given I am a user logged into the system 
	And I am friends with a certain user
	When I send a message to this user
	Then my message is in their inbox
	And is in my sent messages