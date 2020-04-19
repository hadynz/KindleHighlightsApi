using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> FindBookByIdAsync(Guid bookId);
        Task<Book> FindBookByAsinAsync(string asin);
        Task CreateBookAsync(Book book);
        bool BookExists(Guid bookId);
    }
}
