using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class BookHighlightsDto
    {
        public Guid BookId { get; set; }
        public IEnumerable<BookHighlightDto> Highlights { get; set; }
    }
}
