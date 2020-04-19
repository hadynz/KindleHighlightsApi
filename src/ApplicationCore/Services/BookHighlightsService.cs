using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Repositories;

namespace ApplicationCore.Services
{
    public class BookHighlightsService : IBookHighlightsService
    {
        private readonly IBookService _bookService;
        private readonly IBookHighlightsRepository _repository;

        public BookHighlightsService(IBookService bookService, IBookHighlightsRepository repository)
        {
            _bookService = bookService;
            _repository = repository;
        }

        public async Task<IEnumerable<BookHighlight>> GetBookHighlights(Guid bookId)
        {
            var book = await _bookService.FindBookByIdAsync(bookId);

            if (book == null)
            {
                return null;
            }

            return await _repository.GetBookHighlights(bookId);
        }

        public async Task<IEnumerable<BookHighlight>> CreateBookHighlightsAsync(IEnumerable<BookHighlightCreateCommand> createCommands)
        {
            var bookId = createCommands.First().BookId;
            var book = await _bookService.FindBookByIdAsync(bookId);

            if (book == null)
            {
                return null;
            }

            var bookHighlights = createCommands.Select(createCommand => new BookHighlight(createCommand));
            await _repository.CreateBookHighlightsAsync(bookHighlights);
            return bookHighlights;
        }
    }
}
