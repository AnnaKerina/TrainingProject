using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime DateCreated { get; set; }
        public string Summary { get; set; }
        public List<Post> Posts { get; set; }
    }
}
