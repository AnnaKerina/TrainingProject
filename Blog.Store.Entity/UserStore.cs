using System;
using System.Collections.Generic;
using System.Data.Entity;
using Models;
using System.Threading.Tasks;

namespace Blog.Store.Entity
{

    public class UserStore : GenericRepository<User>, IStore.IUserStore
    {
        private readonly IDatabaseContext _databaseContext;
        public UserStore(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public void AddUser(User user)
        {
            user.CreatedTime = DateTime.UtcNow;
            Add(user);
        }

        public void EditUser(User user, int userId)
        {
            var editUser = GetById(userId);
            if (editUser != null)
            {
                editUser.Age = user.Age;
                editUser.UserName = user.UserName;
                editUser.LastName = user.LastName;
                editUser.Summary = user.Summary;
            }
        }

        public Task CreateAsync(User user)
        {
            _databaseContext.Users.Add(user);

            return _databaseContext.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
            if (user != null)
            {
                user.PasswordHash = user.PasswordHash;
                user.UserName = user.UserName;
                user.LastName = user.LastName;
                user.Email = user.Email;
                user.LastModified = DateTime.UtcNow;
            }
            return _databaseContext.SaveChangesAsync();
        }

        public Task DeleteAsync(User user)
        {
            _databaseContext.Users.Remove(user);
            return _databaseContext.SaveChangesAsync();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public Task<User> FindByNameAsync(string userEmail)
        {
            return _databaseContext.Users.FirstOrDefaultAsync(x => x.Email == userEmail);
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }


        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return _databaseContext.SaveChangesAsync();

        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }


        public Task<bool> HasPasswordAsync(User user)
        {
            if (user != null && user.PasswordHash != null)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public void EditUser(User user)
        {
            user.LastModified = DateTime.UtcNow;
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}