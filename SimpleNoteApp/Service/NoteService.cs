using SimpleNoteApp.Models;

namespace SimpleNoteApp.Service
{
    public class NoteService
    {
        private readonly List<Note> _notes = new List<Note>();
        private int _nextId = 1;

        public List<Note> GetAllNotes()=> _notes;

        public Note? GetById(int id) => _notes.FirstOrDefault(n => n.Id == id);

        public Note Create(string title, string content)
        {
            var note = new Note
            {
                Id = _nextId++,
                Title = title,
                Content = content,
            };
            _notes.Add(note);
            return note;
        }

        public bool Update(int id, string title, string content)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note is null) return false;

            note.Title = title;
            note.Content = content;
            return true;
        }
        public bool Delete(int id)
        {
            var note = GetById(id);
            if (note == null) return false;
            _notes.Remove(note);
            return true;
        }
    }
}
