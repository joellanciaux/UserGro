using System;
using System.Collections.Generic;
using System.Linq;
using UserGro.Model.Interfaces;
using System.Data.Entity;

namespace UserGro.Model.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private Context Context { get; set; }

        public UserRepository()
        {
            Context = new Context();
        }

        public IList<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public IList<User> Find(string queryString)
        {
            var users = from u in Context.Users
                        where u.Name.Contains(queryString) ||
                              u.UserName.Contains(queryString)
                        select u;

            return users.ToList();
        }

        public User GetOne(string id)
        {
            return Context.Users.Find(id);
        }

        public User GetOneByName(string name)
        {
            return Context.Users.FirstOrDefault(x => x.Name == name);
        }

        public User Save(User item)
        {
            Context.Users.Add(item);
            Context.SaveChanges();
            return item; 
        }

        public bool Delete(User item)
        {
            if (!Context.Users.Contains(item))
                return false;   

            Context.Users.Remove(item);
            Context.SaveChanges();

            return true;
        }
    }
}
