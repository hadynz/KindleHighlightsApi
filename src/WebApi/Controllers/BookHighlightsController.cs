using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models;
using WebApi.Mapper;
using ApplicationCore.Services;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/books/{bookId:guid}/highlights")]
    [ApiController]
    public class BookHighlightsController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookHighlightsService _bookHighlightsService;
        private readonly IBookHighlightsMapper _bookHighlightsMapper;

        public BookHighlightsController(IBookService bookService, IBookHighlightsService bookHighlightsService, IBookHighlightsMapper bookHighlightsMapper)
        {
            _bookService = bookService;
            _bookHighlightsService = bookHighlightsService;
            _bookHighlightsMapper = bookHighlightsMapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookHighlightsDto>> GetBookHighlight([FromRoute]Guid bookId)
        {
            var highlights = await _bookHighlightsService.GetBookHighlights(bookId);

            if (highlights == null)
            {
                return UnprocessableEntity("Book does not exist");
            }

            return new BookHighlightsDto()
            {
                BookId = bookId,
                Highlights = highlights.Select(h => _bookHighlightsMapper.MapToBookPostResponse(h))
            };
        }

        [HttpPost]
        public async Task<ActionResult<BookHighlight>> PostBookHighlight(Guid bookId, IEnumerable<BookHighlightsPostRequestDto> bookHighlights)
        {
            var createCommands = _bookHighlightsMapper.Map(bookId, bookHighlights);

            if (createCommands == null)
            {
                return BadRequest("At least one book highlight must be created.");
            }

            var highlights = await _bookHighlightsService.CreateBookHighlightsAsync(createCommands);

            if (highlights == null)
            {
                return UnprocessableEntity("Book does not exist");
            }

            var response = _bookHighlightsMapper.MapToBookHighlightsPostResponse(bookId);
            return CreatedAtAction(nameof(GetBookHighlight), new { bookId }, response);
        }
    }
}
