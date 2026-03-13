using System;

namespace Core
{
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
    }
}