using System;
using UserGro.Model;

namespace UserGro.Tests.Behavior
{
    public class BaseBehaviorTest
    {
        protected bool setUp;
        protected User michaelBluth;
        protected User tobias;
        protected User gobBluth;
        protected Event magicShow;
        protected Group blueManGroup;

        protected User GetAdministratorUser()
        {
            return new User()
                       {
                           Name = "G.O.B. Bluth",
                           Email = "resident@thebluthcompany.net",
                           AllowsMessagesFromNonFriends = false,
                           ProfileForFriendsOnly = true,
                           RequiresApprovalToFriend = true,
                           UserName = "mrbananagrabber",
                           State = "CA",
                           City = "Newport Beach",
                           PostalCode = 92663,
                           StreetAddress = "5124 Marina Street"
                       };
        }

        protected User GetPrimaryUser()
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

        protected User GetSecondaryUser()
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

        protected Event GetEvent()
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

        protected Group GetGroup()
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


        public void setup()
        {
            if (setUp)
                return;

            gobBluth = GetAdministratorUser();
            michaelBluth = GetPrimaryUser();
            tobias = GetSecondaryUser();
            blueManGroup = GetGroup();
            magicShow = GetEvent();

            blueManGroup.Administrators.Add(gobBluth);

            setUp = true;
        }
    }
}