Feature: Privacy
	In order to maintain my privacy
	As a site user	
	I want to control who can see my profile

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
	Then they are not added to my friends list twice

	Given I am a user that does NOT require authentication to be my friend
	When a user requests to be my friend 
	Then they are added to my friends list
	And I am added to their friend list

	Given I am a user that does NOT require authentication to be my friend
	When a friend requests to be my friend 
	Then they are not added to my friends list twice

	Given I am a user that has a friend in my awaiting confirmation list
	When I approve the friend
	Then the friend is added to my friends list
	And is no longer in my awaiting confirmation list 
	And I am in their friends list

	Given I am a user that has a friend in my awaiting confirmation list 
	And the user is somehow in my friend list
	When I approve the friend
	Then the friend is still only in my friends list once
	And is no longer in my awaiting confirmation list
	And I am in their friends list

