using System;

namespace KindleHighlightsApi.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Asin { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}