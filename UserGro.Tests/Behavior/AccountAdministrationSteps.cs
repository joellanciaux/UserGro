using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UserGro.Tests.Behavior
{
    [TestFixture]
    [Binding]
    public class AccountAdministration
    {
        [Given(@"I am a potential user")]
        public void GivenIAmAPotentialUser()
        {
            ScenarioContext.Current.Pending();
        }

       [Given(@"I change my email address")]
        public void GivenIChangeMyEmailAddress()
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"the email address is not associated with another account")]
        public void GivenTheEmailAddressIsNotAssociatedWithAnotherAccount()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the email address is associated with another user")]
        public void GivenTheEmailAddressIsAssociatedWithAnotherUser()
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"I change my RequiresApprovalToBeFriends")]
        public void GivenIChangeMyRequiresApprovalToBeFriends()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I change my profile to be visible to friends only")]
        public void GivenIChangeMyProfileToBeVisibleToFriendsOnly()
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"I change my profile to allow messages from non-friends")]
        public void GivenIChangeMyProfileToAllowMessagesFromNon_Friends()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I change my name")]
        public void GivenIChangeMyName()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I sign up for an account that is available")]
        public void WhenISignUpForAnAccountThatIsAvailable()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I sign up for an account that is not available")]
        public void WhenISignUpForAnAccountThatIsNotAvailable()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it is given to me")]
        public void ThenItIsGivenToMe()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it will not allow me to have that account")]
        public void ThenItWillNotAllowMeToHaveThatAccount()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the change is set in the system")]
        public void ThenTheChangeIsSetInTheSystem()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"no change is made")]
        public void ThenNoChangeIsMade()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"an exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
