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
    class PrivacySteps : BaseBehaviorTest
    {
        [Given(@"I am a user that allows friends only to view page")]
        public void GivenIAmAUserThatAllowsFriendsOnlyToViewPage()
        {
            setup();
            michaelBluth.ProfileForFriendsOnly = true;
        }

        [Given(@"I am a user that requires authentication to be my friend")]
        public void GivenIAmAUserThatRequiresAuthenticationToBeMyFriend()
        {
            setup();
            michaelBluth.RequiresApprovalToFriend = true;
        }

        [Given(@"I am a user that does NOT require authentication to be my friend")]
        public void GivenIAmAUserThatDoesNOTRequireAuthenticationToBeMyFriend()
        {
            setup();
        }


        [Given(@"I am a user that has a friend in my awaiting confirmation list")]
        public void GivenIAmAUserThatHasAFriendInMyAwaitingConfirmationList()
        {
            setup();
            michaelBluth.FriendsConfirmation.Add(tobias);
        }

        [Given(@"the user is somehow in my friend list")]
        public void GivenTheUserIsSomehowInMyFriendList()
        {
            michaelBluth.Friends.Add(tobias);
        }

        [When(@"a nonfriend requests my information")]
        public void WhenANonfriendRequestsMyInformation()
        {
        }

        [When(@"a friend requests my information")]
        public void WhenAFriendRequestsMyInformation()
        {
            michaelBluth.AddFriendRequest(tobias);
        }

        [When(@"a friend requests to be my friend")]
        public void WhenAFriendRequestsToBeMyFriend()
        {
            michaelBluth.AddFriendRequest(tobias);
        }

        [When(@"a user requests to be my friend")]
        public void WhenAUserRequestsToBeMyFriend()
        {
            tobias.AddFriendRequest(michaelBluth); 
        }


        [When(@"there is still room to join the event")]
        public void WhenThereIsStillRoomToJoinTheEvent()
        {
            magicShow.Capacity = 5;
        }

        [When(@"I approve the friend")]
        public void WhenIApproveTheFriend()
        {
            michaelBluth.ConfirmFriend(tobias);
        }

        [Then(@"the friend is added to my friends list")]
        public void ThenTheFriendIsAddedToMyFriendsList()
        {
            Assert.That(michaelBluth.Friends.Contains(tobias));
        }

        [Then(@"is no longer in my awaiting confirmation list")]
        public void ThenIsNoLongerInMyAwaitingConfirmationList()
        {
            Assert.That(!michaelBluth.FriendsConfirmation.Contains(tobias));
        }

        [Then(@"the friend is still only in my friends list once")]
        public void ThenTheFriendIsStillOnlyInMyFriendsListOnce()
        {
            Assert.That(michaelBluth.Friends.Where(x => x.Name == "Tobias Fünke").Count() == 1);
        }

        [Then(@"I am in their friends list")]
        public void ThenIAmInTheirFriendsList()
        {
            Assert.That(tobias.Friends.Contains(michaelBluth));
        }

        [Then(@"only basic information is returned")]
        public void ThenOnlyBasicInformationIsReturned()
        {
            //mocking
            var repo = new Mock<IRepository<User>>();
            repo.Setup(x => x.GetOneByName(It.IsAny<string>())).Returns(michaelBluth);

            //only the name should be shown.
            var svc = new UserService(repo.Object);
            var user = svc.GetProfileAsUser(michaelBluth.UserName, tobias);
            
            Assert.IsNullOrEmpty(user.Email);
            Assert.AreEqual(0, user.Friends.Count);
            Assert.AreEqual(0, user.EventsAttending.Count);
            Assert.AreEqual(0, user.Groups.Count);
            Assert.AreEqual(0, user.Talks.Count);
            Assert.AreEqual(michaelBluth.Name, user.Name);
            Assert.AreEqual(michaelBluth.UserName, michaelBluth.UserName);
        }

        [Then(@"my full profile information is displayed")]
        public void ThenMyFullProfileInformationIsDisplayed()
        {
            var mocky = new Mock<IRepository<User>>();
            mocky.Setup(x => x.GetOneByName(It.IsAny<string>())).Returns(michaelBluth);

            var svc = new UserService(mocky.Object);
            var user = svc.GetProfileAsUser("michaelbluth", tobias);

            //basically make sure they have full profile access.
            Assert.AreEqual(michaelBluth.Name, user.Name);
            Assert.AreEqual(michaelBluth.Email, user.Email);
            Assert.AreEqual(michaelBluth.UserName, user.UserName);

        }

        [Then(@"they are added to awaiting approval")]
        public void ThenTheyAreAddedToAwaitingApproval()
        {
            Assert.That(michaelBluth.FriendsConfirmation.Contains(tobias));
        }

        [Then(@"not added to friends")]
        public void ThenNotAddedToFriends()
        {
             Assert.That(!michaelBluth.Friends.Contains(tobias));
        }

        [Then(@"they are added to my friends list")]
        public void ThenTheyAreAddedToMyFriendsList()
        {
            Assert.That(michaelBluth.Friends.Contains(tobias));
        }

        [Then(@"I am added to their friend list")]
        public void ThenIAmAddedToTheirFriendList()
        {
            Assert.That(tobias.Friends.Contains(michaelBluth));
        }
        [Then(@"they are not added to my friends list twice")]
        public void ThenTheyAreNotAddedToMyFriendsListTwice()
        {
            Assert.That(michaelBluth.Friends.Count == 1); 
            Assert.That(michaelBluth.Friends.Contains(tobias));
        }
    }
}
