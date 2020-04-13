using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAllBooksAsync();
        }

        public async Task<Book> FindBookByIdAsync(Guid bookId)
        {
            return await _repository.FindBookByIdAsync(bookId);
        }

        public async Task CreateBookAsync(Book book)
        {
            await _repository.CreateBookAsync(book);
        }

        public bool BookExists(Guid bookId)
        {
            return _repository.BookExists(bookId);
        }
    }
}