using Models;

namespace Blog.IStore
{
    public interface IUserStore
    {
        void AddUser(User user);
        void EditUser(User user, int id);
        void RemoveUser(int id);
    }
}