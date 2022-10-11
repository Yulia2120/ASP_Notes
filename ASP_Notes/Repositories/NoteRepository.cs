using ASP_Notes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Notes.Repositories
{
    public class NoteRepository 
    {
        private readonly NotesAPIDbContext _db;
        public NoteRepository(NotesAPIDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddNote(Note entity)
        {
            _db.Notes.Add(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string title)
        {

            var result = await _db.Notes
                 .FirstOrDefaultAsync(e => e.Title == title);
            if (result != null)
            {
                _db.Notes.Remove(result);
                await _db.SaveChangesAsync();
            }
            return true;
        }
        public async Task UpdateNoteAsync(Note note)
        {
            var noteFromDb = await _db.Notes.FindAsync(new object[] { note.Id });
            if (noteFromDb == null) return;
            noteFromDb.Title = note.Title;
            noteFromDb.Text = note.Text;
            noteFromDb.CreationDate = note.CreationDate;
            await _db.SaveChangesAsync();
        }

        public IAsyncEnumerable<Note> GetAllNotes()
        {
            return _db.Notes.AsAsyncEnumerable();
        }
        public async Task<Note?> GetByTitle(string title)
        {
            return await _db.Notes.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<Note?> Get(int id)
        {
            return await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }

        
    }
}
