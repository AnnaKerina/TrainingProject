using System;
using System.Data.Entity;
using Models;

namespace Blog.Store.Entity
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}