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
        public IList<User> FriendsConfirmation { get; set; }
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
            FriendsConfirmation = new List<User>();
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

        public User AddFriendRequest(User friendRequest)
        {
            if (friendRequest.RequiresApprovalToFriend)
            {
                friendRequest.FriendsConfirmation.Add(this);
                return this;
            }

            this.Friends.Add(friendRequest);
            friendRequest.Friends.Add(this);
            return this;
        }

        /// <summary>
        /// This adds the friend if it's not already in the list of friends
        /// </summary>
        /// <param name="friend"></param>
        internal void AddFriend(User friend)
        {
            if (!this.Friends.Contains(friend))
            {
                this.Friends.Add(friend);
            }
        }

        public User ConfirmFriend(User newFriend)
        {
            if(this.FriendsConfirmation.Contains(newFriend))
            {

                this.AddFriend(newFriend);
                newFriend.AddFriend(this);

                this.FriendsConfirmation.Remove(newFriend);
            }

            return this;
        }

        public User JoinGroup(Group group)
        {
            if (group.RequiresApproval)
            {
                group.AwaitingApproval.Add(this);
                return this;
            }

            group.Users.Add(this);
            this.Groups.Add(group);

            return this; 
        }

        public User RegisterForEvent(Event eventToAttend)
        {
            if (!eventToAttend.HasAvailability())
            {
                //do nothing here | TODO: service should return some sort of notification
                return this; 
            }

            if (eventToAttend.RequiresApproval)
            {
                eventToAttend.AwaitingApproval.Add(this);
                return this;
            }

            eventToAttend.Attendees.Add(this);
            EventsAttending.Add(eventToAttend);
            return this;
        }
    }
}
