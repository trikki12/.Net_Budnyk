namespace Core
{
    public class Category : BaseEntity, IShow
    {
        public string Description { get; set; }
        public bool IsImportant { get; set; }

        public override string GetSummary()
        {
            return $"{Title} (Important: {IsImportant})";
        }

        public void Display()
        {
            System.Console.WriteLine($"[CATEGORY] {Title} - {Description}");
        }
    }
}