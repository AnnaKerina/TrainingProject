using System.Data.Entity;
using System.Reflection;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly configurationAssembly = Assembly.GetAssembly(GetType());
            modelBuilder.Configurations.AddFromAssembly(configurationAssembly);
        }
    }
}
