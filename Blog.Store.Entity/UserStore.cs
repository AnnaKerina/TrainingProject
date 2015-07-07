using System;
using Models;

namespace Blog.Store.Entity
{

    public class UserStore : GenericRepository<User>, IStore.IUserStore
    {


        private static readonly IDatabaseContext _databaseContext;

        public UserStore(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }


        public void AddUser(User user)
        {
            user.DateCreated = DateTime.UtcNow;
            Add(user);
        }

        public void EditUser(User user, int userId)
        {
            var editUser = GetById(userId);
            if (editUser != null)
            {
                editUser.Age = user.Age;
                editUser.Name = user.Name;
                editUser.Surname = user.Surname;
                editUser.Summary = user.Summary;
            }
        }

        public void RemoveUser(int userId)
        {
            Remove(GetById(userId));
        }
    }
}