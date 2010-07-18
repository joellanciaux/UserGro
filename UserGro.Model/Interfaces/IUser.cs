using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGro.Model.Interfaces
{
    public interface IUser : ILocation
    {
        //this will be the ID
        string UserName { get; set; }
        string Name { get; set; }
        string Email { get; set; } //Encrypt this.
        bool RequiresApprovalToFriend { get; set; }
        bool ProfileForFriendsOnly { get; set; }
        //ugly names - thank God we can ReSharper this later.
        bool AllowsMessagesFromNonFriends { get; set; }

        IList<User> Friends { get; set; }
        IList<User> AwaitingApproval { get; set; }
        IList<Group> Groups { get; set; }
        IList<Group> GroupsAdmin { get; set; }
        //things like facebook/twitter profiles, etc.
        IList<Identity> Identities { get; set; }
        IList<Event> EventsAttending { get; set; }
        IList<Event> EventsAdmin { get; set; }
        IList<Talk> Talks { get; set; }
        IList<Message> Messages { get; set; }
        IList<Message> ArchivedMessages { get; set; }

        IUserViewModel ToViewModel();
    }
}
