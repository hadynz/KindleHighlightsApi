using ApplicationCore.Models;

namespace WebApi.Mapper
{
    public interface IBookHighlightsMapper
    {
        BookHighlightDto MapToBookPostResponse(BookHighlight bookHighlight);
    }
}
