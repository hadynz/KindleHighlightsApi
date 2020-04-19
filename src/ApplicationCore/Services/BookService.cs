using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using ApplicationCore.Models.Exceptions;

namespace ApplicationCore.Services
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
            var books = await _repository.GetAllBooksAsync();
            return books.OrderByDescending(book => book.CreatedAtUtc);
        }

        public async Task<Book> FindBookByIdAsync(Guid bookId)
        {
            return await _repository.FindBookByIdAsync(bookId);
        }

        public async Task<Book> CreateBookAsync(BookCreateCommand createCommand)
        {
            var existingBook = await _repository.FindBookByAsinAsync(createCommand.Asin);

            if (existingBook != null)
            {
                throw new ConflictEntityException("Book already exists", existingBook.BookId);
            }

            var book = new Book(createCommand);
            await _repository.CreateBookAsync(book);
            return book;
        }
    }
}
