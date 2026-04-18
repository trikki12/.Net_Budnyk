using System;
using Core;

class Program
{
    static void Main()
    {
        // Композиція
        AppController controller = new AppController();
        controller.ShowAppInfo();

        // Об'єкти
        Note note = new Note
        {
            Title = "Lab 4",
            Content = "OOP concepts",
            CreatedDate = DateTime.Now
        };

        Category category = new Category
        {
            Title = "Study",
            Description = "Learning OOP",
            IsImportant = true
        };

        // Агрегація
        NoteManager manager = new NoteManager();
        manager.Add(note);

        Console.WriteLine("\nAGGREGATION:");
        foreach (var n in manager.GetAll())
        {
            Console.WriteLine(n.GetSummary());
        }

        // Поліморфізм
        IShow[] items = new IShow[]
        {
            note,
            category
        };

        Console.WriteLine("\nPOLYMORPHISM:");
        foreach (var item in items)
        {
            item.Display();
        }

        Console.ReadLine();
    }
}