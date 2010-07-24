Feature: Account administration
	In order to modify my account
	As a user	
	I want to be able to change my settings

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
