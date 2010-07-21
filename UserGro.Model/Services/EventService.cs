using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserGro.Model.Interfaces;
using UserGro.Model.Repositories;

namespace UserGro.Model.Services
{
    public class EventService
    {
        private IRepository<Event> _repo;

        public EventService()
        {
            _repo = new EventRepository();
        }

        public EventService(IRepository<Event> repo)
        {
            _repo = repo;
        }

        public Event GetEventByName(string name)
        {
            return _repo.GetOneByName(name);
        }

        
    }
}
