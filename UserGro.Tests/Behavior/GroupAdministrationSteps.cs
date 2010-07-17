using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UserGro.Tests.Behavior
{
    [TestFixture]
    [Binding]
    public class  GroupAdministrationSteps
    {
        
        [Given(@"I am an existing user")]
        public void GivenIAmAnExistingUser()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am a group admin")]
        public void GivenIAmAGroupAdmin()
        {
            ScenarioContext.Current.Pending();
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
            ScenarioContext.Current.Pending();
        }

        [Then(@"the group is added to events I'm admin")]
        public void ThenTheGroupIsAddedToEventsIMAdmin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it is added to the other group's admins events admin")]
        public void ThenItIsAddedToTheOtherGroupSAdminsEventsAdmin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}