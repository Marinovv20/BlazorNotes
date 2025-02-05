using BlazorNotes.Shared.Models;
using BlazorNotes.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNotes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase
	{
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
			_noteService = noteService;
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Note>> GetNoteById(int id)
		{
			var note = await _noteService.GetNoteById(id);
			return Ok(note);
		}

		[HttpPost]
		public async Task<ActionResult<Note>> AddNote(Note note)
		{
			var addedNote = await _noteService.AddNote(note);
			return Ok(addedNote);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Note>> EditNote(int id, Note note)
		{
			var updatedNote = await _noteService.EditNote(id, note);
			return Ok(updatedNote);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Note>> DeleteNote(int id)
		{
			var result = await _noteService.DeleteNote(id);
			return Ok(result);
		}
	}
}
