using Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("OS Version: " + Environment.OSVersion);

        Console.WriteLine("Memory used: " + GC.GetTotalMemory(false));

        Note note = new Note
        {
            Title = "Lab work",
            Content = "I need to finish my lab. And i'm showing my work at:",
            CreatedDate = DateTime.Now
        };

        Category category = new Category
        {
            Name = "Study",
            Description = "At the moment we are learning C# and .Net",
            IsImportant = true
        };

        User user = new User
        {
            Username = "Oleksii"
        };

        Console.WriteLine("\nNote:");
        Console.WriteLine(note.Title);
        Console.WriteLine(note.Content);
        Console.WriteLine(note.CreatedDate);

        Console.WriteLine("\nCategory:");
        Console.WriteLine(category.Name);
        Console.WriteLine(category.Description);
        Console.WriteLine(category.IsImportant);

        Console.WriteLine("\nUser:");
        Console.WriteLine(user.Username);

        Console.ReadLine();
    }
}