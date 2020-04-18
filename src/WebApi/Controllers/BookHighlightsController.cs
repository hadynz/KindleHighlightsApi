using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.DBContext;
using ApplicationCore.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookHighlightsController : ControllerBase
    {
        private readonly BookHighlightsContext _context;

        public BookHighlightsController(BookHighlightsContext context)
        {
            _context = context;
        }

        // GET: api/BookHighlights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookHighlight>>> GetBookHighlight()
        {
            return await _context.BookHighlight.ToListAsync();
        }

        // GET: api/BookHighlights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookHighlight>> GetBookHighlight(Guid id)
        {
            var bookHighlight = await _context.BookHighlight.FindAsync(id);

            if (bookHighlight == null)
            {
                return NotFound();
            }

            return bookHighlight;
        }

        // PUT: api/BookHighlights/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookHighlight(Guid id, BookHighlight bookHighlight)
        {
            if (id != bookHighlight.BookHighlightId)
            {
                return BadRequest();
            }

            _context.Entry(bookHighlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookHighlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookHighlights
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookHighlight>> PostBookHighlight(BookHighlight bookHighlight)
        {
            _context.BookHighlight.Add(bookHighlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookHighlight", new { id = bookHighlight.BookHighlightId }, bookHighlight);
        }

        // DELETE: api/BookHighlights/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookHighlight>> DeleteBookHighlight(Guid id)
        {
            var bookHighlight = await _context.BookHighlight.FindAsync(id);
            if (bookHighlight == null)
            {
                return NotFound();
            }

            _context.BookHighlight.Remove(bookHighlight);
            await _context.SaveChangesAsync();

            return bookHighlight;
        }

        private bool BookHighlightExists(Guid id)
        {
            return _context.BookHighlight.Any(e => e.BookHighlightId == id);
        }
    }
}
