using NUnit.Framework;
using TechTalk.SpecFlow;
using UserGro.Model;

namespace UserGro.Tests.Behavior
{
    [TestFixture]
    [Binding]
    public class  GroupAdministrationSteps : BaseBehaviorTest
    {
        
        [Given(@"I am an existing user")]
        public void GivenIAmAnExistingUser()
        {
            setup();
        }

        [Given(@"I am a group admin")]
        public void GivenIAmAGroupAdmin()
        {
            setup();

            // I know this should be Tobias, but he's the secondary user. . . 
            blueManGroup.Administrators.Add(michaelBluth); 
        }


        [When(@"I need a speaker for a new event")]
        public void WhenINeedASpeakerForANewEvent()
        {
            ScenarioContext.Current.Pending();
        }
 
        [Then(@"I can push a notification that I am looking for speakers for that event")]
        public void ThenICanPushANotificationThatIAmLookingForSpeakersForThatEvent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I try to create a new event for the group")]
        public void WhenITryToCreateANewEventForTheGroup()
        {
            
            ScenarioContext.Current.Pending();
        }

        [Then(@"the event is added to my events I'm attending")]
        public void ThenTheEventIsAddedToMyEventsIMAttending()
        {
            Assert.IsTrue(michaelBluth.EventsAttending.Contains(magicShow));
        }

        [Then(@"the group is added to events I'm admin")]
        public void ThenTheGroupIsAddedToEventsIMAdmin()
        {
            Assert.IsTrue(michaelBluth.EventsAdmin.Contains(magicShow));
        }

        [Then(@"it is added to the other group's admins events admin")]
        public void ThenItIsAddedToTheOtherGroupSAdminsEventsAdmin()
        {
            Assert.IsTrue(gobBluth.EventsAdmin.Contains(magicShow)); 
        }
    }
}