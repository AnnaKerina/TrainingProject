using System;

namespace Blog.Store.Entity
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDatabaseContext _databaseContext;
        private bool _disposed;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _disposed = false;
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

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                _databaseContext.Dispose();
            }

            this._disposed = true;
        }
    }
}