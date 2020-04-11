using KindleHighlightsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KindleHighlightsApi.DBContext
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}