using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGro.Model.Interfaces
{
    public interface IUser
    {
        //this will be the ID
        string UserName { get; set; }
        string Name { get; set; }
        string Email { get; set; } //Encrypt this.
        bool RequiresApprovalToFriend { get; set; }
        bool ProfileForFriendsOnly { get; set; }
        //ugly names - thank God we can ReSharper this later.
        bool AllowsMessagesFromNonFriends { get; set; }

        IList<IUser> Friends { get; set; }
        IList<IUser> AwaitingApproval { get; set; }
        IList<IGroup> Groups { get; set; }
        IList<IGroup> GroupsAdmin { get; set; }
        //things like facebook/twitter profiles, etc.
        IList<Identity> Identities { get; set; }
        IList<Event> EventsAttending { get; set; }
        IList<Event> EventsAdmin { get; set; }
        IList<Talk> Talks { get; set; }
        IList<Message> Messages { get; set; }
        IList<Message> ArchivedMessages { get; set; }

    }
}
