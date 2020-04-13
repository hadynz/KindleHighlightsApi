using ApplicationCore.Models;

namespace WebApi.Mapper
{
    public class BookMapper : IBookMapper
    {
        public BookCreateCommand Map(BookPostRequestDto bookDto)
        {
            return new BookCreateCommand
            {
                Asin = bookDto.Asin,
                Author = bookDto.Author,
                BookUrl = bookDto.BookUrl,
                ImageUrl = bookDto.ImageUrl,
                Title = bookDto.Title
            };
        }

        public BookDto Map(Book book)
        {
            return new BookDto
            {
                BookId = book.BookId,
                Asin = book.Asin,
                Title = book.Title,
                Author = book.Author,
                ImageUrl = book.ImageUrl,
                BookUrl = book.BookUrl,
                CreatedAt = book.CreatedAtUtc,
                UpdatedAt = book.CreatedAtUtc
            };
        }
    }
}