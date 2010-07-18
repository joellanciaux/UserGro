using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserGro.Model.Interfaces;

namespace UserGro.Model.Repositories
{
    class UserRepository : IRepository<User>
    {
        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<User> Find(string queryString)
        {
            throw new NotImplementedException();
        }

        public User GetOne(string Id)
        {
            throw new NotImplementedException();
        }

        public User GetOneByName(string name)
        {
            throw new NotImplementedException();
        }

        public User Save(User item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }
    }
}
