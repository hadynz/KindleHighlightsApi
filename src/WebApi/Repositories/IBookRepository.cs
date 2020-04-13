using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> FindBookByIdAsync(Guid bookId);
        Task CreateBookAsync(Book book);
        bool BookExists(Guid bookId);
    }
}