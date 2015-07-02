using System;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}