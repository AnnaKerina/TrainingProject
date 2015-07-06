using System.Collections.Generic;

namespace Blog.Store.Entity
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T item);
        
        IList<T> GetAll();
        
        T GetById(int id);
       
        void Remove(T item);

        void Update(T item, int id);
    }
}