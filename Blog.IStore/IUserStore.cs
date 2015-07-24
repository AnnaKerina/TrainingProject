using Microsoft.AspNet.Identity;
using Models;

namespace Blog.IStore
{
    public interface IUserStore : IUserPasswordStore<User, int>, IUserRoleStore<User, int>
    {
        void AddUser(User user);
        void EditUser(User user, int id);
    }
}