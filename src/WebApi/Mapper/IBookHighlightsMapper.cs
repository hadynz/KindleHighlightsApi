using System;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace WebApi.Mapper
{
    public interface IBookHighlightsMapper
    {
        BookHighlightDto MapToBookPostResponse(BookHighlight bookHighlight);
        IEnumerable<BookHighlightCreateCommand> Map(Guid bookId, IEnumerable<BookHighlightsPostRequestDto> bookHighlightDtos);
        BookHighlightsPostResponse MapToBookHighlightsPostResponse(Guid bookId);
    }
}
