using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> FindBookByIdAsync(Guid bookId);
        Task CreateBookAsync(Book book);
        bool BookExists(Guid bookId);
    }
}