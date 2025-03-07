﻿using BlazorNotes.Shared.Data;
using BlazorNotes.Shared.Models;

namespace BlazorNotes.Shared.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetAllNotes();
        Task<Note> GetNoteById(int id);
        Task<Note> AddNote(Note note);
        Task<Note> EditNote(int id, Note note);
        Task<bool> DeleteNote(int id);
    }
}
