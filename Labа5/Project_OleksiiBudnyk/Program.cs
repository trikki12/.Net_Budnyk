using System;
using System.Collections.Generic;
using Core;

class Program
{
    static void Main()
    {
        string jsonPath = "notes.json";
        string xmlPath = "notes.xml";
        string logPath = "log.txt";

        List<Note> notes = new List<Note>
        {
            new Note
            {
                Title = "Lab 5",
                Content = "Learning JSON and XML serialization",
                CreatedDate = DateTime.Now
            },
            new Note
            {
                Title = "Old note",
                Content = "This note was created earlier",
                CreatedDate = DateTime.Now.AddDays(-5)
            },
            new Note
            {
                Title = "Study",
                Content = "Repeat IDisposable and using",
                CreatedDate = DateTime.Now.AddDays(-1)
            }
        };

        using (ResourceManager resourceManager = new ResourceManager(logPath))
        {
            resourceManager.WriteLog("Program started");

            NoteJsonStorage.SaveToJson(notes, jsonPath);
            resourceManager.WriteLog("Notes saved to JSON");

            List<Note> loadedNotes = NoteJsonStorage.LoadFromJson(jsonPath);
            resourceManager.WriteLog("Notes loaded from JSON");

            Console.WriteLine("LOADED NOTES FROM JSON:");
            foreach (var note in loadedNotes)
            {
                Console.WriteLine($"{note.Title} | {note.Content} | {note.CreatedDate}");
            }

            NoteXmlExporter.ExportRecentNotes(notes, xmlPath);
            resourceManager.WriteLog("Recent notes exported to XML");

            Console.WriteLine("\nXML export completed.");
            Console.WriteLine("Log file created.");

            resourceManager.WriteLog("Program finished");
        }

        Console.ReadLine();
    }
}