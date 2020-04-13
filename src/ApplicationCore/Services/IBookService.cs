using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> FindBookByIdAsync(Guid bookId);
        Task<Book> CreateBookAsync(BookCreateCommand createCommand);
        bool BookExists(Guid bookId);
    }
}