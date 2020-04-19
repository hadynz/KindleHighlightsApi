using System;

namespace ApplicationCore.Models
{
    public class BookHighlightDto
    {
        public Guid BookHighlightId { get; set; }
        public string Text { get; set; }
        public string AnnotationId { get; set; }
        public string LocationPercentage { get; set; }
    }
}
