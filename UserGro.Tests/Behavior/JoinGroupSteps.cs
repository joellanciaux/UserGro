using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UserGro.Tests.Behavior
{
    [Binding]
    class JoinGroupSteps : BaseBehaviorTest
    {
        [Given(@"I am a user that is not part of the local blue man group")]
        public void GivenIAmAUserThatIsNotPartOfTheLocalBlueManGroup()
        {
            setup();
        }

        [Given(@"the group does not require approval")]
        public void WhenTheGroupDoesNotRequireApproval()
        {
            blueManGroup.RequiresApproval = false;
        }

        [Given(@"the group DOES require approval")]
        public void WhenTheGroupDOESRequireApproval()
        {
            blueManGroup.RequiresApproval = true;
        }

        [When(@"I attempt to join the group")]
        public void WhenIAttemptToJoinTheGroup()
        {
            michaelBluth.JoinGroup(blueManGroup);
        }

        [Then(@"it is added to my groups")]
        public void ThenItIsAddedToMyGroups()
        {
            Assert.That(michaelBluth.Groups.Contains(blueManGroup));
        }

        [Then(@"I am added to the groups Awaiting approval")]
        public void ThenIAmAddedToTheGroupsAwaitingApproval()
        {
            Assert.That(!michaelBluth.Groups.Contains(blueManGroup));
        }
    }
}
