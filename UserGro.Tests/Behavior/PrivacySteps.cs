using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UserGro.Model;
using UserGro.Model.Interfaces;
using UserGro.Model.Services;

namespace UserGro.Tests.Behavior
{
    [Binding]
    class PrivacySteps
    {
        private User mainUser;
        private User secondaryUser;
        private Event mainEvent;
        private Group group; 

        private User GetPrimaryUser()
        {
            var user = new User();
            user.Name = "Michael Bluth";
            user.Email = "michael@thebluthcompany.net";
            user.AllowsMessagesFromNonFriends = true;
            user.ProfileForFriendsOnly = false;
            user.RequiresApprovalToFriend = false;
            user.UserName = "michaelbluth";
            user.State = "CA";
            user.City = "Los Angeles";
            user.PostalCode = 91039;
            user.StreetAddress = "123 Sudden Valley Drive";

            return user;
        }

        private User GetSecondaryUser()
        {
            var user = new User();
            user.Name = "Tobias Fünke"; // Bonus umlaut
            user.Email = "tobias@tobiasisqueenmary.net";
            user.AllowsMessagesFromNonFriends = true;
            user.ProfileForFriendsOnly = false;
            user.RequiresApprovalToFriend = false;
            user.UserName = "blueman99";
            user.State = "CA";
            user.City = "Los Angeles";
            user.PostalCode = 91039;
            user.StreetAddress = "123 Sudden Valley Drive";

            return user;
        }

        private Event GetEvent()
        {
            var groupEvent = new Event();
            groupEvent.State = "CA";
            groupEvent.City = "Los Angeles";
            groupEvent.Country = "USA";
            groupEvent.PostalCode = 91039;
            groupEvent.StreetAddress = "";
            groupEvent.WebAddress = "MAGIC SHOW!!!!";
            groupEvent.StartDate = DateTime.Now.AddDays(14);
            groupEvent.OnlineOnly = false;

            return groupEvent;
        }

        private Group GetGroup()
        {
            return new Group
                            {
                                City = "Los Angeles",
                                Country = "USA",
                                Name = "Blue Man Group",
                                OnlineOnly = false,
                                PostalCode = 91039,
                                State = "CA",
                                StreetAddress = "1234 Hidden Valley",
                                WebAddress = "http://www.somesite.com"
                            };
        }

        [Given(@"I am a user that allows friends only to view page")]
        public void GivenIAmAUserThatAllowsFriendsOnlyToViewPage()
        {
            mainUser = GetPrimaryUser();
            mainUser.ProfileForFriendsOnly = true;
        }

        [Given(@"I am a user that requires authentication to be my friend")]
        public void GivenIAmAUserThatRequiresAuthenticationToBeMyFriend()
        {
            mainUser = GetPrimaryUser();
            mainUser.RequiresApprovalToFriend = true;
        }

        [Given(@"I am a user that does NOT require authentication to be my friend")]
        public void GivenIAmAUserThatDoesNOTRequireAuthenticationToBeMyFriend()
        {
            mainUser = GetPrimaryUser();
        }

        [Given(@"I am a user that is not part of the local \.NET group")]
        public void GivenIAmAUserThatIsNotPartOfTheLocal_NETGroup()
        {
            mainUser = GetPrimaryUser();
        }

        [Given(@"I am a user that wants to attend a local day of \.NET")]
        public void GivenIAmAUserThatWantsToAttendALocalDayOf_NET()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a user logged into the system")]
        public void GivenIAmAUserLoggedIntoTheSystem()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a user that is an event admin")]
        public void GivenIAmAUserThatIsAnEventAdmin()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a user that wants to start an event")]
        public void GivenIAmAUserThatWantsToStartAnEvent()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a user that has a friend in my awaiting confirmation list")]
        public void GivenIAmAUserThatHasAFriendInMyAwaitingConfirmationList()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the user is somehow in my friend list")]
        public void GivenTheUserIsSomehowInMyFriendList()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I create an event")]
        public void WhenICreateAnEvent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I remove an attendee")]
        public void WhenIRemoveAnAttendee()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I promote another user to admin the event")]
        public void WhenIPromoteAnotherUserToAdminTheEvent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"they allow messages to be sent to them from nonfriends")]
        public void WhenTheyAllowMessagesToBeSentToThemFromNonfriends()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I am not their friend")]
        public void WhenIAmNotTheirFriend()
        {
            ScenarioContext.Current.Pending();
        }
 
        [When(@"they do NOT allow messages to be sent to them from nonfriends")]
        public void WhenTheyDoNOTAllowMessagesToBeSentToThemFromNonfriends()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I send a message to another user")]
        public void WhenISendAMessageToAnotherUser()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the user is my friend")]
        public void WhenTheUserIsMyFriend()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I send a message to a non-existant user")]
        public void WhenISendAMessageToANon_ExistantUser()
        {
            ScenarioContext.Current.Pending();
        }
       
        [When(@"a nonfriend requests my information")]
        public void WhenANonfriendRequestsMyInformation()
        {
            secondaryUser = GetSecondaryUser();
        }

        [When(@"a friend requests my information")]
        public void WhenAFriendRequestsMyInformation()
        {
            secondaryUser = GetSecondaryUser();
            mainUser.AddFriend(secondaryUser);
        }

        [When(@"a friend requests to be my friend")]
        public void WhenAFriendRequestsToBeMyFriend()
        {
            secondaryUser = GetSecondaryUser();
            mainUser.AddFriend(secondaryUser);
        }

        [When(@"a user requests to be my friend")]
        public void WhenAUserRequestsToBeMyFriend()
        {
            secondaryUser.AddFriend(mainUser); 
        }

        [When(@"the group does not require approval")]
        public void WhenTheGroupDoesNotRequireApproval()
        {
            group.RequiresApproval = false;
        }

        [When(@"I attempt to join the group")]
        public void WhenIAttemptToJoinTheGroup()
        {
            group = GetGroup();
            mainUser.AddGroup(group);
        }

        [When(@"the group DOES require approval")]
        public void WhenTheGroupDOESRequireApproval()
        {
            group.RequiresApproval = true;
        }

        [When(@"I attempt to register for the event")]
        public void WhenIAttemptToRegisterForTheEvent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"there is still room to join the event")]
        public void WhenThereIsStillRoomToJoinTheEvent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I approve the friend")]
        public void WhenIApproveTheFriend()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the friend is added to my friends list")]
        public void ThenTheFriendIsAddedToMyFriendsList()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"is no longer in my awaiting confirmation list")]
        public void ThenIsNoLongerInMyAwaitingConfirmationList()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the friend is still only in my friends list once")]
        public void ThenTheFriendIsStillOnlyInMyFriendsListOnce()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"only basic information is returned")]
        public void ThenOnlyBasicInformationIsReturned()
        {
            //mocking
            var repo = new Mock<IRepository<User>>();
            repo.Setup(x => x.GetOneByName(It.IsAny<string>())).Returns(mainUser);

            //only the name should be shown.
            var svc = new UserService(repo.Object);
            var user = svc.GetProfileAsUser(mainUser.UserName, secondaryUser);
            
            Assert.IsNullOrEmpty(user.Email);
            Assert.AreEqual(0, user.Friends.Count);
            Assert.AreEqual(0, user.EventsAttending.Count);
            Assert.AreEqual(0, user.Groups.Count);
            Assert.AreEqual(0, user.Talks.Count);
            Assert.AreEqual(mainUser.Name, user.Name);
            Assert.AreEqual(mainUser.UserName, mainUser.UserName);
        }

        [Then(@"my full profile information is displayed")]
        public void ThenMyFullProfileInformationIsDisplayed()
        {
            var mocky = new Mock<IRepository<User>>();
            mocky.Setup(x => x.GetOneByName(It.IsAny<string>())).Returns(mainUser);

            var svc = new UserService(mocky.Object);
            var user = svc.GetProfileAsUser("michaelbluth", secondaryUser);

            //basically make sure they have full profile access.
            Assert.AreEqual(mainUser.Name, user.Name);
            Assert.AreEqual(mainUser.Email, user.Email);
            Assert.AreEqual(mainUser.UserName, user.UserName);

        }

        [Then(@"they are added to awaiting approval")]
        public void ThenTheyAreAddedToAwaitingApproval()
        {
            Assert.That(mainUser.ConfirmFriends.Contains(secondaryUser));
        }

        [Then(@"not added to friends")]
        public void ThenNotAddedToFriends()
        {
             Assert.That(!mainUser.Friends.Contains(secondaryUser));
        }

        [Then(@"they are added to my friends list")]
        public void ThenTheyAreAddedToMyFriendsList()
        {
            Assert.That(mainUser.Friends.Contains(secondaryUser));
        }

        [Then(@"I am added to their friend list")]
        public void ThenIAmAddedToTheirFriendList()
        {
            Assert.That(secondaryUser.Friends.Contains(mainUser));
        }
        [Then(@"they are not added to my friends list twice")]
        public void ThenTheyAreNotAddedToMyFriendsListTwice()
        {
            Assert.That(mainUser.Friends.Count == 1); 
            Assert.That(mainUser.Friends.Contains(secondaryUser));
        }

        [Then(@"it is added to my groups")]
        public void ThenItIsAddedToMyGroups()
        {
            Assert.That(mainUser.Groups.Contains(group));
        }

        [Then(@"I am added to the groups Awaiting approval")]
        public void ThenIAmAddedToTheGroupsAwaitingApproval()
        {
            Assert.That(!mainUser.Groups.Contains(group));
        }

        [Then(@"I am added to the event's attendee's")]
        public void ThenIAmAddedToTheEventSAttendeeS()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the event is added to my EventsAttending")]
        public void ThenTheEventIsAddedToMyEventsAttending()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it gets added to my events admin")]
        public void ThenItGetsAddedToMyEventsAdmin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it gets added to my events attending")]
        public void ThenItGetsAddedToMyEventsAttending()
        {
            ScenarioContext.Current.Pending();
        }
 
        [Then(@"they are no longer in the list of those coming")]
        public void ThenTheyAreNoLongerInTheListOfThoseComing()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"they are promoted to admin")]
        public void ThenTheyArePromotedToAdmin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"my message is in their inbox")]
        public void ThenMyMessageIsInTheirInbox()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"my message is NOT in their inbox")]
        public void ThenMyMessageIsNOTInTheirInbox()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I receive an exception")]
        public void ThenIReceiveAnException()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
