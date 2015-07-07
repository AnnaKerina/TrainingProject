using System;

namespace Blog.Store.Entity
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDatabaseContext _databaseContext;
        private bool _disposed;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}