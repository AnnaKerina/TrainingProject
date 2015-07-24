using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Models
{

    public class User : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime CreatedTime { get; set; }

        public int Age { get; set; }

//        public Role Role { get; set; }

        public string Summary { get; set; }

        public List<Post> Posts { get; set; }
    }
}
