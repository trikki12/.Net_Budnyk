namespace Core
{
    public abstract class BaseEntity
    {
        public string Title { get; set; }

        // virtual реалізація
        public virtual void ShowInfo()
        {
            System.Console.WriteLine($"Title: {Title}");
        }

        // abstract (обов'язково перепреділяємо)
        public abstract string GetSummary();
    }
}