﻿using ASP_Notes.Models;
using ASP_Notes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private readonly NoteRepository _noteRepository;
        public NoteController(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        [HttpGet("GetNotes")]
        public IAsyncEnumerable<Note> GetNotes()
        {
            return _noteRepository.GetAllNotes();
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Note note = await _noteRepository.Get(id);

            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);

        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post(Note note)
        {
          await _noteRepository.AddNote(note);

            return Ok(note);

        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update(Note note)
        {
            await _noteRepository.UpdateNoteAsync(note);
          
            return Ok(note);
        }
        
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string note)
        {
           await _noteRepository.Delete(note);
          
            return Ok(note);
        }
    }
}
