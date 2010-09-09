using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UserGro.Tests.Behavior
{
    [Binding]
    public class MessageSteps : BaseBehaviorTest
    {
        [Given(@"I am a user logged into the system")]
        public void GivenIAmAUserLoggedIntoTheSystem()
        {
            setup();
            // do nothing we're using the main user here
        }

        [Given(@"I am not friends with a certain user")]
        public void GivenIAmNotFriendsWithACertainUser()
        {
            //by default secondary and main user are not friends so do nothing here also
        }

        [Given(@"they do NOT allow messages to be sent from nonfriends")]
        public void GivenTheyDoNOTAllowMessagesToBeSentFromNonfriends()
        {
            tobias.AllowsMessagesFromNonFriends = false;
        } 
       
        [Given(@"I am friends with a certain user")]
        public void GivenIAmFriendsWithACertainUser()
        {
            setup();

            //skip the normal channels for adding friends here -- just add
            michaelBluth.Friends.Add(tobias);
            tobias.Friends.Add(michaelBluth);
        }

        [Given(@"they allow messages to be sent from nonfriends")]
        public void GivenTheyAllowMessagesToBeSentFromNonfriends()
        {
            tobias.AllowsMessagesFromNonFriends = true;
        }

        [When(@"I send a message to this user")]
        public void WhenISendAMessageToThisUser()
        {
            michaelBluth.SendMessage(tobias, "Hi this is a test message", "Test!");
            
        }

        [Then(@"my message is in their inbox")]
        public void ThenMyMessageIsInTheirInbox()
        {
            Assert.That(tobias.Messages.Count == 1);
            Assert.That(tobias.Messages[0].Title == "Test!");
            Assert.That(tobias.Messages[0].MessageBody == "Hi this is a test message");

        }

        [Then(@"my message is NOT in their inbox")]
        public void ThenMyMessageIsNOTInTheirInbox()
        {
            Assert.That(tobias.Messages.Count == 0);
        }

        [Then(@"is in my sent messages")]
        public void ThenIsInMySentMessages()
        {
            Assert.That(michaelBluth.SentMessages.Count == 1);
            Assert.That(michaelBluth.SentMessages[0].Title == "Test!");
            Assert.That(michaelBluth.SentMessages[0].MessageBody == "Hi this is a test message");
        }

        [Then(@"is NOT in my sent messages")]
        public void ThenIsNOTInMySentMessages()
        {
            Assert.That(michaelBluth.SentMessages.Count == 0);
        }

    }
}