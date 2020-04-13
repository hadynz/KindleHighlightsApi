using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
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

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return books.Select(b => _bookMapper.Map(b)).ToList();
        }

        // GET: api/Books/5
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

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookPostResponseDto>> PostBook(BookPostRequestDto bookPost)
        {
            var bookCreateCommand = _bookMapper.Map(bookPost);
            var book = await _bookService.CreateBookAsync(bookCreateCommand);
            
            var response = _bookMapper.MapToBookPostResponse(book);
            return CreatedAtAction("GetBook", new { id = book.BookId }, response);
        }

        private bool BookExists(Guid id)
        {
            return _bookService.BookExists(id);
        }
    }
}
