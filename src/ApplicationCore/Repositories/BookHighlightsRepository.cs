using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DBContext;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Repositories
{
    public class BookHighlightsRepository : IBookHighlightsRepository
    {
        private readonly BookHighlightsContext _dbContext;

        public BookHighlightsRepository(BookHighlightsContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<BookHighlight>> GetBookHighlights(Guid bookId)
        {
            return await _dbContext.BookHighlights.Where(h => h.BookId == bookId).ToListAsync();
        }

        public async Task CreateBookHighlightsAsync(Guid bookId, IEnumerable<BookHighlight> bookHighlights)
        {
            var existingAnnotationIds = _dbContext.BookHighlights.Where(h => h.BookId == bookId).Select(h => h.AnnotationId).ToList();
            var newHighlights = bookHighlights.Where(b => !existingAnnotationIds.Contains(b.AnnotationId));

            _dbContext.BookHighlights.AddRange(newHighlights);
            await _dbContext.SaveChangesAsync();
        }
    }
}
