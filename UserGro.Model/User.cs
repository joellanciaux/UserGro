using System;
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
        public virtual IList<IUser> Friends { get; set; }
        public virtual IList<IGroup> Groups { get; set; }


        public User()
        {
            Friends = new List<IUser>();
            Groups = new List<IGroup>();
        }
    }
}
