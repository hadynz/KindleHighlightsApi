using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Models;

namespace WebApi.Mapper
{
    public class BookHighlightsMapper : IBookHighlightsMapper
    {
        public BookHighlightDto MapToBookPostResponse(BookHighlight bookHighlight)
        {
            return new BookHighlightDto
            {
                BookHighlightId = bookHighlight.BookHighlightId,
                LocationPercentage = bookHighlight.LocationPercentage,
                Text = bookHighlight.Text,
                AnnotationId = bookHighlight.AnnotationId
            };
        }

        public IEnumerable<BookHighlightCreateCommand> Map(Guid bookId, IEnumerable<BookHighlightsPostRequestDto> bookHighlightDtos)
        {
            var highlights = bookHighlightDtos.ToList();

            if (highlights.Count == 0)
            {
                return null;
            }

            return highlights.Select(b => new BookHighlightCreateCommand
            {
                BookId = bookId,
                Text = b.Text,
                AnnotationId = b.AnnotationId,
                LocationPercentage = b.LocationPercentage
            });
        }

        public BookHighlightsPostResponse MapToBookHighlightsPostResponse(Guid bookId)
        {
            return new BookHighlightsPostResponse()
            {
                BookId = bookId
            };
        }
    }
}
