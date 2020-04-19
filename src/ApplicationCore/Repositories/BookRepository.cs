using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DBContext;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> FindBookByIdAsync(Guid bookId)
        {
            return await _dbContext.Books.FindAsync(bookId);
        }

        // Find book by Amazon Standard Identification Numbers (ASIN)
        public async Task<Book> FindBookByAsinAsync(string asin)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Asin == asin);
        }

        public async Task CreateBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public bool BookExists(Guid bookId)
        {
            return _dbContext.Books.Any(book => book.BookId == bookId);
        }
    }
}
