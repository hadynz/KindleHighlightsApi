using ApplicationCore.Models;

namespace WebApi.Mapper
{
    public interface IBookMapper
    {
        BookCreateCommand Map(BookPostRequestDto bookDto);
        BookDto Map(Book book);
    }
}