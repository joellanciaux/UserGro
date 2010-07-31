using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserGro.Model.Interfaces;
using UserGro.Model.Repositories;


namespace UserGro.Model.Services
{
    public class GroupServices
    {
        private IRepository<Group> _repo;

        public GroupServices()
        {
            _repo = new GroupRepository();
        }
    }
}
