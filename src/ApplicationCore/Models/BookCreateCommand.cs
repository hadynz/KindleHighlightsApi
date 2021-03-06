using System;

namespace ApplicationCore.Models
{
    public class BookCreateCommand
    {
        public Guid BookId { get; set; }
        public string Asin { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }
    }
}