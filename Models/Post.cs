using System;
using System.Collections.Generic;

namespace Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}