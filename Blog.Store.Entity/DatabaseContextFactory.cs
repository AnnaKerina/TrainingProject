using System.Data.Entity.Infrastructure;

namespace Blog.Store.Entity
{
    public class DatabaseContextFactory : IDbContextFactory<DatabaseContext>
    {
        public DatabaseContext Create()
        {
            return new DatabaseContext("DefaultConnection");
        }
    }
}