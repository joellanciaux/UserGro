using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using UserGro.Model.Interfaces;
using UserGro.Model.ViewModels;

namespace UserGro.Model
{
    public class User : IUser, ILocation
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool RequiresApprovalToFriend { get; set; }
        public bool ProfileForFriendsOnly { get; set; }
        public bool AllowsMessagesFromNonFriends { get; set; }
        public virtual IList<User> Friends { get; set; }
        public IList<User> AwaitingApproval { get; set; }
        public virtual IList<Group> Groups { get; set; }
        public IList<Group> GroupsAdmin { get; set; }
        public IList<Identity> Identities { get; set; }
        public IList<Event> EventsAttending { get; set; }
        public IList<Event> EventsAdmin { get; set; }
        public IList<Talk> Talks { get; set; }
        public IList<Message> Messages { get; set; }
        public IList<Message> ArchivedMessages { get; set; }
        public IList<Website> Websites { get; set;}

        public User()
        {
            Friends = new List<User>();
            AwaitingApproval = new List<User>();
            Groups = new List<Group>();
            Messages = new List<Message>();
            GroupsAdmin = new List<Group>();
            Identities = new List<Identity>();
            EventsAttending = new List<Event>();
            EventsAdmin = new List<Event>();
            Talks = new List<Talk>();
            Messages = new List<Message>();
            ArchivedMessages = new List<Message>();
            Websites = new List<Website>();
        }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public IUserViewModel ToViewModel()
        {
            Mapper.CreateMap<IUser, IUserViewModel>();
            return Mapper.Map<IUser, IUserViewModel>(this);
        }

        public User AddFriend(User secondaryUser)
        {
            this.Friends.Add(secondaryUser);
            secondaryUser.Friends.Add(this);
            return this;
        }
    }
}
