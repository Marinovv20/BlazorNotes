using BlazorNotes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNotes.Shared.Services
{
	public class ClientNoteService : INoteService
	{
		private readonly HttpClient _httpClient;

        public ClientNoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Note> AddNote(Note note)
		{
			var result = await _httpClient
				.PostAsJsonAsync<Note>("/api/note", note);
			return await result.Content.ReadFromJsonAsync<Note>();
		}

		public async Task<bool> DeleteNote(int id)
		{
			var result = await _httpClient.DeleteAsync($"api/note/{id}");
			return await result.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<Note> EditNote(int id, Note note)
		{
			var result = await _httpClient.PutAsJsonAsync($"api/note/{id}", note);
			return await result.Content.ReadFromJsonAsync<Note>();
		}

		public Task<List<Note>> GetAllNotes()
		{
			throw new NotImplementedException();
		}

		public async Task<Note> GetNoteById(int id)
		{
			var result = await _httpClient
				.GetFromJsonAsync<Note>($"api/note/{id}");
			return result;
		}
	}
}
