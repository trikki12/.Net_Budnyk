using System;

namespace Core
{
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\nContent: {Content}\nCreated: {CreatedDate}";
        }
    }
}