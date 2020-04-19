using System;

namespace ApplicationCore.Models
{
    public class BookHighlightCreateCommand
    {
        public Guid BookId { get; set; }
        public string AnnotationId { get; set; }
        public string Text { get; set; }
        public string LocationPercentage { get; set; }
    }
}
