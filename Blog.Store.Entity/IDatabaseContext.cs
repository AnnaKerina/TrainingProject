using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Models;

namespace Blog.Store.Entity
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}