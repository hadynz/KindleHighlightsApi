using System;

namespace ApplicationCore.Models
{
    public class Book
    {
        public Guid BookId { get; private set; }
        public string Asin { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ImageUrl { get; private set; }
        public string BookUrl { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime UpdatedAtUtc { get; private set; }

        public Book()
        {
            // Required by EF
        }
        public Book(BookCreateCommand createCommand)
        {
            BookId = Guid.NewGuid();
            Asin = createCommand.Asin;
            Title = createCommand.Title;
            Author = createCommand.Author;
            ImageUrl = createCommand.ImageUrl;
            BookUrl = createCommand.BookUrl;
            CreatedAtUtc = DateTime.UtcNow;
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}