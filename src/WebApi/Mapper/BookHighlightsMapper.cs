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
                Text = bookHighlight.Text
            };
        }
    }
}
