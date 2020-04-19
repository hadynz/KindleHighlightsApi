using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.DBContext;
using ApplicationCore.Models;
using WebApi.Mapper;
using ApplicationCore.Services;

namespace WebApi.Controllers
{
    [Route("api/books/{bookId:guid}/highlights")]
    [ApiController]
    public class BookHighlightsController : ControllerBase
    {
        private readonly BookHighlightsContext _context;
        private readonly IBookService _bookService;
        private readonly IBookHighlightsMapper _bookHighlightsMapper;

        public BookHighlightsController(BookHighlightsContext context, IBookService bookService, IBookHighlightsMapper bookHighlightsMapper)
        {
            _context = context;
            _bookService = bookService;
            _bookHighlightsMapper = bookHighlightsMapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookHighlightsDto>> GetBookHighlight([FromRoute]Guid bookId)
        {
            var book = await _bookService.FindBookByIdAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }

            var highlights = await _context.BookHighlights.Where(h => h.BookId == bookId).ToListAsync();

            return new BookHighlightsDto()
            {
                Highlights = highlights.Select(h => _bookHighlightsMapper.MapToBookPostResponse(h))
            };
        }

        [HttpPost]
        public async Task<ActionResult<BookHighlight>> PostBookHighlight(Guid bookId, BookHighlight bookHighlight)
        {
            _context.BookHighlights.Add(bookHighlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookHighlight", new { id = bookHighlight.BookHighlightId }, bookHighlight);
        }
    }
}
