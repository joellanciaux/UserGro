using System.Collections.Generic;

namespace UserGro.Model.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        IList<T> Find(string queryString);
        T GetOne(string Id);
        T GetOneByName(string name);
        T Save(T item);
        bool Delete(T item);
    }
}