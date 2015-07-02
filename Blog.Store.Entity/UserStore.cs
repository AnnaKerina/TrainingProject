using System;
using Models;

namespace Blog.Store.Entity
{

    public class UserStore : GenericRepository<User>, IStore.IUserStore
    {

        public UserStore(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public void AddUser(User user)
        {
            user.DateCreated = DateTime.UtcNow;
            Add(user);
        }

        public void EditUser(User user, int userId)
        {
            var oldUser = GetById(userId);
            if (oldUser != null)
            {
                oldUser.Age = user.Age;
                oldUser.Name = user.Name;
                oldUser.Surname = user.Surname;
                oldUser.Summary = user.Summary;
            }
        }

        public void RemoveUser(int userId)
        {
            Remove(GetById(userId));
        }
    }
}