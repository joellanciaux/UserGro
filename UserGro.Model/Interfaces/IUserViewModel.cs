using System.Collections.Generic;

namespace UserGro.Model.Interfaces
{
    public interface IUserViewModel
    {
        string UserName { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        IList<User> Friends { get; set; }
        IList<Group> Groups { get; set; }
        IList<Identity> Identities { get; set; }
        IList<Event> EventsAttending { get; set; }
        IList<Talk> Talks { get; set; }
        IList<Website> Websites { get; set; }
    }
}