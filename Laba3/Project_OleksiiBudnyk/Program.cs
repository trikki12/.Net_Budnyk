using System;
using System.Collections.Generic;
using Core;

class Program
{
    static void Main()
    {
        // БАЗОВІ ДАНІ (з попередніх лаб)
        Note note = new Note
        {
            Title = "Lab 3",
            Content = "This is my third lab work example",
            CreatedDate = DateTime.Now
        };

        Console.WriteLine("NOTE:");
        Console.WriteLine(note);

        // 1. EXTENSION METHOD
        Console.WriteLine("\nWORD COUNT:");
        Console.WriteLine(note.Content.WordCount());

        // 2. NOTE MANAGER (контейнер)
        NoteManager manager = new NoteManager();

        manager.Add(new Note { Title = "Task1", Content = "Hello world", CreatedDate = DateTime.Now });
        manager.Add(new Note { Title = "Task2", Content = "Study C#", CreatedDate = DateTime.Now });
        manager.Add(new Note { Title = "Task3", Content = "Go gym", CreatedDate = DateTime.Now.AddDays(-2) });

        // 3. FOREACH (yield return)
        Console.WriteLine("\nITERATION:");
        foreach (var n in manager)
        {
            Console.WriteLine(n.Title);
        }

        // 4. DICTIONARY
        manager.AddWithId(new Note { Title = "Special1", Content = "Test", CreatedDate = DateTime.Now.AddDays(-1) });
        manager.AddWithId(new Note { Title = "Special2", Content = "Old", CreatedDate = DateTime.Now.AddDays(-3) });
        manager.AddWithId(new Note { Title = "Special3", Content = "New", CreatedDate = DateTime.Now});

        var found = manager.GetById(0);

        Console.WriteLine("\nSEARCH BY ID:");
        if (found != null)
        {
            Console.WriteLine(found.Title);
        }

        // 5. LINQ для Dictionary
        Console.WriteLine("\nRECENT NOTES:");
        var recent = manager.GetRecentNotes();

        foreach (var n in recent)
        {
            Console.WriteLine(n.Title);
        }

        // 6. HASHSET
        HashSet<string> tags1 = new HashSet<string> { "work", "study", "home" };
        HashSet<string> tags2 = new HashSet<string> { "study", "health" };

        tags1.Add("study"); // дубль

        Console.WriteLine("\nHASHSET 1:");
        foreach (var t in tags1)
        {
            Console.WriteLine(t);
        }

        // Перетин
        tags1.IntersectWith(tags2);

        Console.WriteLine("\nINTERSECTION:");
        foreach (var t in tags1)
        {
            Console.WriteLine(t);
        }

        Console.ReadLine();
    }
}