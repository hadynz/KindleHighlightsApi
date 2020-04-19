using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Repositories
{
    public interface IBookHighlightsRepository
    {
        Task<IEnumerable<BookHighlight>> GetBookHighlights(Guid bookId);
        Task CreateBookHighlightsAsync(Guid bookId, IEnumerable<BookHighlight> bookHighlights);
    }
}
