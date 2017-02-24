using System.Collections.Generic;

namespace Tibox.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T GetEntityById(int id);
        IEnumerable<T> GetAll();
    }
}
