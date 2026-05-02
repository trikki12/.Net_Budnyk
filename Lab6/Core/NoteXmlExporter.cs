using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Core
{
    public static class NoteXmlExporter
    {
        public static void ExportRecentNotes(List<Note> notes, string filePath)
        {
            var recentNotes = notes
                .Where(n => n.CreatedDate >= DateTime.Now.AddDays(-2));

            XDocument document = new XDocument(
                new XElement("Notes",
                    recentNotes.Select(note =>
                        new XElement("Note",
                            new XElement("Title", note.Title),
                            new XElement("Content", note.Content),
                            new XElement("CreatedDate", note.CreatedDate)
                        )
                    )
                )
            );

            document.Save(filePath);
        }

        public static List<Note> LoadFromXml(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<Note>();
            }

            try
            {
                XDocument document = XDocument.Load(filePath);

                if (document.Root == null)
                {
                    return new List<Note>();
                }

                return document.Root
                    .Elements("Note")
                    .Select(x =>
                    {
                        DateTime createdDate;
                        DateTime.TryParse((string?)x.Element("CreatedDate"), out createdDate);

                        return new Note
                        {
                            Title = (string?)x.Element("Title") ?? "",
                            Content = (string?)x.Element("Content") ?? "",
                            CreatedDate = createdDate == default ? DateTime.Now : createdDate
                        };
                    })
                    .ToList();
            }
            catch
            {
                return new List<Note>();
            }
        }
    }
}