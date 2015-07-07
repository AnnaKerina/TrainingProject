using System.Collections.Generic;
using System.Data.Entity;

namespace Blog.Store.Entity
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T item);
        
        T GetById(int id);
       
        void Remove(T item);

        void Update(T item, int id);

        DbSet<T> EntityDbSet { get; }
    }
}