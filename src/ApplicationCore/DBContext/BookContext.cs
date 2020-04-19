using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.DBContext
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookHighlight> BookHighlights { get; set; }
    }
}
