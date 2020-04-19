using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Models.Exceptions;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookMapper _bookMapper;

        public BooksController(IBookService bookService, IBookMapper bookMapper)
        {
            _bookService = bookService;
            _bookMapper = bookMapper;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return books.Select(b => _bookMapper.Map(b)).ToList();
        }

        // GET: api/books/<guid>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(Guid id)
        {
            var book = await _bookService.FindBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return _bookMapper.Map(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookPostResponseDto>> PostBook(BookPostRequestDto bookPost)
        {
            try
            {
                var createCommand = _bookMapper.Map(bookPost);
                var book = await _bookService.CreateBookAsync(createCommand);

                var response = _bookMapper.MapToBookPostResponse(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, response);
            }
            catch (ConflictEntityException ex)
            {
                return Conflict(new
                {
                    message = "Book already exists",
                    bookId = ex.ReferenceId
                });
            }
        }
    }
}
