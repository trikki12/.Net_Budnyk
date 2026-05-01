using System.Collections.Generic;

namespace Core
{
    public class NoteManager
    {
        private List<Note> notes = new List<Note>();

        // агренація приймає всі створені об'єкти
        public void Add(Note note)
        {
            notes.Add(note);
        }

        public List<Note> GetAll()
        {
            return notes;
        }
    }
}