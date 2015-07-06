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
                    new User{Id = 1, Name = "Ivan", Age = 24},
                    new User{Id = 2, Name = "Vitaly", Age = 39},
                    new User{Id = 3, Name = "Viktor", Age = 28},
                    new User{Id = 4, Name = "Alex", Age = 32},
                };
            }
        }
    }
}