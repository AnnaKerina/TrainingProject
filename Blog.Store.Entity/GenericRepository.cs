using System.Collections.Generic;
using System.Linq;

namespace Blog.Store.Entity
{
    public class GenericRepository<T> where T : class
    {
        private readonly IDatabaseContext _databaseContext;

        public GenericRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(T item)
        {
            _databaseContext.Set<T>().Add(item);
        }

        public void Remove(T item)
        {
            _databaseContext.Set<T>().Remove(item);
        }

        public IList<T> GetAll()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _databaseContext.Set<T>().Find(id);
        }
    }
}