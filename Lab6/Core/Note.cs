using System;

namespace Core
{
    public class Note : BaseEntity, IShow
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Note()
        {
        }

        public override string GetSummary()
        {
            return $"{Title} ({CreatedDate})";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine($"Created: {CreatedDate}");
        }

        public void Display()
        {
            Console.WriteLine($"[NOTE] {Title} - {Content}");
        }
    }
}