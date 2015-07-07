using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.Store.Entity
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDatabaseContext _databaseContext;

        public GenericRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public DbSet<T> EntityDbSet
        {
            get { return _databaseContext.Set<T>(); }
        }

        public void Add(T item)
        {
            _databaseContext.Set<T>().Add(item);
        }

        public void Remove(T item)
        {
            _databaseContext.Set<T>().Remove(item);
        }

        public virtual void Update(T item, int id)
        {
            
        }

        public T GetById(int id)
        {
            return _databaseContext.Set<T>().Find(id);
        }
    }
}