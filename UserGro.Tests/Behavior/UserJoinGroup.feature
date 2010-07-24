Feature: Join Groups 
	In order to be involved in the community
	As a programmer 
	I want to join nearby groups 

Scenario: User join group
	Given I am a user that is not part of the local blue man group
	And the group does not require approval 
	When I attempt to join the group
	Then it is added to my groups

	Given I am a user that is not part of the local blue man group
	And the group DOES require approval
	When I attempt to join the group
	Then I am added to the groups Awaiting approval







	
