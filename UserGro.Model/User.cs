using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserGro.Model.Interfaces;

namespace UserGro.Model
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool RequiresApprovalToFriend { get; set; }
        public bool ProfileForFriendsOnly { get; set; }
        public bool AllowsMessagesFromNonFriends { get; set; }
        public bool RequiresApproval { get; set; }
        public virtual IList<IUser> Friends { get; set; }
        public IList<IUser> AwaitingApproval { get; set; }
        public virtual IList<IGroup> Groups { get; set; }
        public IList<IGroup> GroupsAdmin { get; set; }
        public IList<Identity> Identities { get; set; }
        public IList<Event> EventsAttending { get; set; }
        public IList<Event> EventsAdmin { get; set; }
        public IList<Talk> Talks { get; set; }
        public IList<Message> Messages { get; set; }
        public IList<Message> ArchivedMessages { get; set; }

        public User()
        {
            Friends = new List<IUser>();
            Groups = new List<IGroup>();
        }
    }
}
