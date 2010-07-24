using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UserGro.Tests.Behavior
{
    [Binding]
    class JoinEventSteps :BaseBehaviorTest
    {
        [Given(@"I want to go to the MAGIC SHOW event")]
        public void GivenIWantToGoToTheMAGICSHOWEvent()
        {
            setup();
            //this is dumb but I guess i just wanted the scenario to sound better
        }

        [Given(@"the event is not moderated")]
        public void GivenTheEventIsNotModerated()
        {
            magicShow.RequiresApproval = false;
        }

        [Given(@"there is no room left")]
        public void GivenThereIsNoRoomLeft()
        {
            magicShow.Capacity = 0;
        }

        [Given(@"there is room left")]
        public void GivenThereIsRoomLeft()
        {
            magicShow.Capacity = 500;
        }

        [Given(@"the event is moderated")]
        public void GivenTheEventIsModerated()
        {
            magicShow.RequiresApproval = true;
        }

        [When(@"I attempt to register for the event")]
        public void WhenIAttemptToRegisterForTheEvent()
        {
            michaelBluth.RegisterForEvent(magicShow);
        }

        [Then(@"I am NOT added to the event's attendees")]
        public void ThenIAmNOTAddedToTheEventSAttendees()
        {
            Assert.That(!magicShow.Attendees.Contains(michaelBluth));
        }

        [Then(@"the event is NOT added to my EventsAttending")]
        public void ThenTheEventIsNOTAddedToMyEventsAttending()
        {
            Assert.That(!michaelBluth.EventsAttending.Contains(magicShow));
        }

        [Then(@"I am added to the event's attendees")]
        public void ThenIAmAddedToTheEventSAttendees()
        {
            Assert.That(magicShow.Attendees.Contains(michaelBluth));
        }

        [Then(@"I am added to the event's awaiting approval")]
        public void ThenIAmAddedToTheEventSAwaitingApproval()
        {
            Assert.That(magicShow.AwaitingApproval.Contains(michaelBluth));
        }

        [Then(@"the event is added to my EventsAttending")]
        public void ThenTheEventIsAddedToMyEventsAttending()
        {
            Assert.That(michaelBluth.EventsAttending.Contains(magicShow));
        }

    }
}
