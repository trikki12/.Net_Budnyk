using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class NoteManager : IEnumerable<Note>
    {
        private List<Note> notes = new List<Note>();
        private Dictionary<int, Note> noteDict = new Dictionary<int, Note>();
        private int currentId = 0;

        // Додавання у список
        public void Add(Note note)
        {
            notes.Add(note);
        }

        // Додавання у словник (з ID)
        public void AddWithId(Note note)
        {
            noteDict[currentId++] = note;
        }

        // Пошук по ID (швидкий)
        public Note GetById(int id)
        {
            return noteDict.ContainsKey(id) ? noteDict[id] : null;
        }

        // LINQ по словнику
        public IEnumerable<Note> GetRecentNotes()
        {
            return noteDict.Values.Where(n => n.CreatedDate >= DateTime.Now.AddDays(-1));
        }

        // Ітерація через foreach (yield)
        public IEnumerator<Note> GetEnumerator()
        {
            foreach (var note in notes)
            {
                yield return note;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}