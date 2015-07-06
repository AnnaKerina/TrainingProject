using System;

namespace Blog.Store.Entity
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}