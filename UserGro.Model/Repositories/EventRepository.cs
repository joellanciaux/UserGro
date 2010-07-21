using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserGro.Model.Interfaces;

namespace UserGro.Model.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private Context Context { get; set; }

        public EventRepository()
        {
            Context = new Context();
        }

        public IList<Event> GetAll()
        {
            return Context.Events.ToList();
        }

        public IList<Event> Find(string queryString)
        {
            var events = from e in Context.Events
                         where e.City.Contains(queryString) ||
                               e.Name.Contains(queryString) ||
                               e.StreetAddress.Contains(queryString) ||
                               e.WebAddress.Contains(queryString) 
                         select e;

            return events.ToList();
        }

        public Event GetOne(string id)
        {
            return Context.Events.Find(id);
        }

        public Event GetOneByName(string name)
        {
            return Context.Events.FirstOrDefault(x => x.Name == name);
        }

        public Event Save(Event item)
        {
            Context.Events.Add(item);
            Context.SaveChanges();

            return item; // ?
        }

        public bool Delete(Event item)
        {
            Context.Events.Remove(item);
            Context.SaveChanges();

            return true;
        }
    }
}
