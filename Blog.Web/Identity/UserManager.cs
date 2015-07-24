using Blog.IStore;
using Microsoft.AspNet.Identity;
using Models;

namespace Blog.Web.Identity
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore store) : base(store)
        {
        }
    }
}