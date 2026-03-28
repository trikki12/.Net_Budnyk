using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            Content = "I need to finish my lab",
            CreatedDate = DateTime.Now
        };

        Category category = new Category
        {
            Name = "Study",
            Description = "Learning C#",
            IsImportant = true
        };

        User user = new User
        {
            Username = "Oleksii"
        };

        Console.WriteLine("\nNote:");
        Console.WriteLine(note);

        Console.WriteLine("\nCategory:");
        Console.WriteLine(category.Name);
        Console.WriteLine(category.Description);
        Console.WriteLine(category.IsImportant);

        Console.WriteLine("\nUser:");
        Console.WriteLine(user.Username);

        // 1. STRUCT
        Price price = new Price { Amount = 100, Currency = "USD" };

        Console.WriteLine("\nSTRUCT TEST:");
        Console.WriteLine("До метода: " + price.Amount);

        ChangePrice(price);

        Console.WriteLine("После метода: " + price.Amount);

        // 2. BOXING / UNBOXING
        Console.WriteLine("\nBOXING TEST:");

        object obj = 5; // boxing
        int num = (int)obj; // unboxing

        Stopwatch sw = new Stopwatch();

        ArrayList arrayList = new ArrayList();
        sw.Start();
        for (int i = 0; i < 1_000_000; i++)
        {
            arrayList.Add(i);
        }
        sw.Stop();
        Console.WriteLine("ArrayList: " + sw.ElapsedMilliseconds + " ms");

        sw.Reset();
        List<int> list = new List<int>();
        sw.Start();
        for (int i = 0; i < 1_000_000; i++)
        {
            list.Add(i);
        }
        sw.Stop();
        Console.WriteLine("List<int>: " + sw.ElapsedMilliseconds + " ms");

        // 3. List NOTE (10 object)
        List<Note> notes = new List<Note>
        {
            new Note { Title="Task1", Content="A", CreatedDate=DateTime.Now },
            new Note { Title="Task2", Content="B", CreatedDate=DateTime.Now.AddDays(-1) },
            new Note { Title="Task3", Content="C", CreatedDate=DateTime.Now.AddDays(-2) },
            new Note { Title="Task4", Content="D", CreatedDate=DateTime.Now },
            new Note { Title="Task5", Content="E", CreatedDate=DateTime.Now },
            new Note { Title="Task6", Content="F", CreatedDate=DateTime.Now.AddDays(-3) },
            new Note { Title="Task7", Content="G", CreatedDate=DateTime.Now },
            new Note { Title="Task8", Content="H", CreatedDate=DateTime.Now.AddDays(-1) },
            new Note { Title="Task9", Content="I", CreatedDate=DateTime.Now },
            new Note { Title="Task10", Content="J", CreatedDate=DateTime.Now }
        };

        Console.WriteLine("\nAll Notes:");
        foreach (var n in notes)
        {
            Console.WriteLine(n);
            Console.WriteLine("-----");
        }

        // 4. WHERE
        Func<Note, bool> recent = n => n.CreatedDate >= DateTime.Now.AddDays(-1);

        var filtered = notes.Where(recent);

        Console.WriteLine("\nFilter (last day):");
        foreach (var n in filtered)
        {
            Console.WriteLine(n.Title + " | " + n.CreatedDate);
        }

        // 5. ORDERBY + THENBY
        var sorted = notes
            .OrderBy(n => n.Title)
            .ThenBy(n => n.CreatedDate);

        Console.WriteLine("\n Sorting:");
        foreach (var n in sorted)
        {
            Console.WriteLine($"{n.Title} | {n.CreatedDate}");
        }

        // 6. SELECT
        var titles = notes.Select(n => n.Title);

        Console.WriteLine("\n Only names:");
        foreach (var t in titles)
        {
            Console.WriteLine(t);
        }

        // 7. FIRSTORDEFAULT
        var found = notes.FirstOrDefault(n => n.Title == "Task1");

        Console.WriteLine("\nSearch:");
        if (found != null)
        {
            Console.WriteLine(found);
        }
        else
        {
            Console.WriteLine("Not found");
        }

        Console.ReadLine();
    }

    static void ChangePrice(Price price)
    {
        price.Amount = 999;
    }
}