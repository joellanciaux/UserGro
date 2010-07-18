using System.Collections.Generic;
using UserGro.Model.Interfaces;

namespace UserGro.Model.ViewModels
{
    public class UserViewModel : IUserViewModel 
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual IList<User> Friends { get; set; }
        public virtual IList<Group> Groups { get; set; }
        public virtual IList<Identity> Identities { get; set; }
        public virtual IList<Event> EventsAttending { get; set; }
        public virtual IList<Talk> Talks { get; set; }
        public virtual IList<Website> Websites { get; set; }

        public UserViewModel()
        {
            Friends = new List<User>();
            Groups = new List<Group>();
            Identities = new List<Identity>();
            EventsAttending = new List<Event>();
            Talks = new List<Talk>();
            Websites = new List<Website>();
        }
    }
}