using System.Collections.Generic;
using System.Data.Entity;
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

        public DbSet<T> EntityDb 
        {
            get { return _databaseContext.Set<T>(); }
        }

        public void Add(T item)
        {
            EntityDb.Add(item);
        }

        public void Remove(T item)
        {
            EntityDb.Remove(item);
        }

        public IList<T> GetAll()
        {
            return EntityDb.ToList();
        }

        public T GetById(int id)
        {
            return EntityDb.Find(id);
        }
    }
}