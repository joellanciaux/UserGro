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

        private User GetUser()
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

        [Given(@"I am a user that allows friends only to view page")]
        public void GivenIAmAUserThatAllowsFriendsOnlyToViewPage()
        {
            mainUser = GetUser();
            mainUser.ProfileForFriendsOnly = true;
        }

        [Given(@"I am a user that requires authentication to be my friend")]
        public void GivenIAmAUserThatRequiresAuthenticationToBeMyFriend()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a user that does NOT require authentication to be my friend")]
        public void GivenIAmAUserThatDoesNOTRequireAuthenticationToBeMyFriend()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a user that is not part of the local \.NET group")]
        public void GivenIAmAUserThatIsNotPartOfTheLocal_NETGroup()
        {
            ScenarioContext.Current.Pending();
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
            secondaryUser=  GetUser();
            secondaryUser.Name = "Tobias Funke";
            secondaryUser.UserName = "blueman99";
        }

        [When(@"a friend requests my information")]
        public void WhenAFriendRequestsMyInformation()
        {
            secondaryUser = GetUser();
            secondaryUser.Name = "Tobias Funke";
            secondaryUser.UserName = "blueman99";

            mainUser.AddFriend(secondaryUser);
        }

        [When(@"a friend requests to be my friend")]
        public void WhenAFriendRequestsToBeMyFriend()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"a user requests to be my friend")]
        public void WhenAUserRequestsToBeMyFriend()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the group does not require approval")]
        public void WhenTheGroupDoesNotRequireApproval()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I attempt to join the group")]
        public void WhenIAttemptToJoinTheGroup()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the group DOES require approval")]
        public void WhenTheGroupDOESRequireApproval()
        {
            ScenarioContext.Current.Pending();
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
            ScenarioContext.Current.Pending();
        }

        [Then(@"not added to friends")]
        public void ThenNotAddedToFriends()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"they are added to my friends list")]
        public void ThenTheyAreAddedToMyFriendsList()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"nothing happens")]
        public void ThenNothingHappens()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it is added to my groups")]
        public void ThenItIsAddedToMyGroups()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I am added to the groups Awaiting approval")]
        public void ThenIAmAddedToTheGroupsAwaitingApproval()
        {
            ScenarioContext.Current.Pending();
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
