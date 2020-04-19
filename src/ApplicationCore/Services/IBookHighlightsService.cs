using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public interface IBookHighlightsService
    {
        Task<IEnumerable<BookHighlight>> GetBookHighlights(Guid bookId);
        Task<IEnumerable<BookHighlight>> CreateBookHighlightsAsync(IEnumerable<BookHighlightCreateCommand> createCommands);
    }
}
