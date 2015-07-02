using System.Data.Entity;
using Models;

namespace Blog.Store.Entity
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        
        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
