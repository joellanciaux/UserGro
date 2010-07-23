using System.Collections.Generic;
using UserGro.Model.Interfaces;

namespace UserGro.Model
{
    public class Group : IGroup, ILocation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual IList<User> Users { get; set; }
        public virtual IList<User> Admininstrators { get; set; }
        public virtual IList<User> AwaitingApproval { get; set; }
        public bool RequiresApproval { get; set; }
        public Group()
        {
            Users = new List<User>();
            Admininstrators = new List<User>();
            AwaitingApproval = new List<User>();
        }

        public bool OnlineOnly { get; set; }
        public string WebAddress { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}