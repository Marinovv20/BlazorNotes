using BlazorNotes.Shared.Data;
using BlazorNotes.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotes.Shared.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Note> AddNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return note;
        }

		public async Task<bool> DeleteNote(int id)
		{
			var dbNote = await _context.Notes.FindAsync(id);
            if (dbNote != null)
            {
                _context.Remove(dbNote);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
		}

		public async Task<Note> EditNote(int id, Note note)
		{
			var dbNote = await _context.Notes.FindAsync(id);
			if (dbNote != null)
			{
				dbNote.Title = note.Title;
                dbNote.Description = note.Description;
                await _context.SaveChangesAsync();
                return dbNote;
			}
            throw new Exception("Game not found.");
		}

		public async Task<List<Note>> GetAllNotes()
        {
           var notes = await _context.Notes.ToListAsync();
            return notes;
        }

		public async Task<Note> GetNoteById(int id)
		{
			return await _context.Notes.FindAsync(id);
		}
	}
}
