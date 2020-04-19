using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class BookHighlightsPostRequestDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public string AnnotationId { get; set; }
        [Required]
        public string LocationPercentage { get; set; }
    }
}
