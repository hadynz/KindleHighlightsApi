using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class BookPostRequestDto
    {
        [Required]
        public string Asin { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string BookUrl { get; set; }
    }
}