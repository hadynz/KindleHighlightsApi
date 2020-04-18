using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.DBContext
{
    public class BookHighlightsContext : DbContext
    {
        public BookHighlightsContext(DbContextOptions<BookHighlightsContext> options)
            : base(options)
        {
        }

        public DbSet<BookHighlight> BookHighlights { get; set; }
    }
}
