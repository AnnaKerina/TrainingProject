using System.Collections.Generic;
using Models;

namespace Blog.Store.Entity.Tests
{
    public class MockRepository
    {
        public List<User> Users
        {
            get
            {
                return new List<User>
                {
                    new User{Id = 1, UserName = "Ivan", Age = 24},
                    new User{Id = 2, UserName = "Vitaly", Age = 39},
                    new User{Id = 3, UserName = "Viktor", Age = 28},
                    new User{Id = 4, UserName = "Alex", Age = 32},
                };
            }
        }

        public Post Post
        {
            get
            {
                return new Post
                {
                    Id = 1,
                    Title = "Title"
                };
            }
        }

        public User User
        {
            get
            {
                return new User {Id = 1, UserName = "Ivan", Age = 24};
            }
        }
    }
}