using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserGro.Model.Interfaces;

namespace UserGro.Model.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private Context Context { get; set; }

        public IList<Group> GetAll()
        {
            return Context.Groups.ToList();
        }

        public IList<Group> Find(string queryString)
        {
            var groups = from g in Context.Groups
                         where g.Name.Contains(queryString) ||
                                g.City.Contains(queryString)
                         select g;

            return groups.ToList();
        }

        public Group GetOne(string id)
        {
            return Context.Groups.Find(id);
        }

        public Group GetOneByName(string name)
        {
            return Context.Groups.FirstOrDefault(x => x.Name == name);
        }

        public Group Save(Group item)
        {
            Context.Groups.Add(item);
            Context.SaveChanges();

            return item; 
        }

        public bool Delete(Group item)
        {
            if (!Context.Groups.Contains(item))
                return false;
            
            Context.Groups.Remove(item);
            Context.SaveChanges();

            return true;
        }
    }
}
