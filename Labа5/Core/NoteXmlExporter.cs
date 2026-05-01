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
    }
}