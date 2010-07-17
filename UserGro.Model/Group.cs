using System.Collections.Generic;
using UserGro.Model.Interfaces;

namespace UserGro.Model
{
    public class Group : IGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual IList<User> Users { get; set; }

        public Group()
        {
            Users = new List<User>();
        }
    }
}