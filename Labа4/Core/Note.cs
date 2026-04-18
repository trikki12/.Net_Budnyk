using System;

namespace Core
{
    public class Note : BaseEntity, IShow
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string GetSummary()
        {
            return $"{Title} ({CreatedDate})";
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Content: {Content}");
        }

        public void Display()
        {
            Console.WriteLine($"[NOTE] {Title} - {Content}");
        }
    }
}