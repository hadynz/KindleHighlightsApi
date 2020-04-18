using System;

namespace ApplicationCore.Models
{
    public class BookHighlight
    {
        public Guid BookId { get; private set; }
        public Guid BookHighlightId { get; private set; }
        public string Text { get; private set; }
        public string LocationPercentage { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime UpdatedAtUtc { get; private set; }

        public BookHighlight()
        {
            // Required by EF
        }

        public BookHighlight(BookHighlightCreateCommand createCommand)
        {
            BookId = createCommand.BookId;
            Text = createCommand.Text;
            LocationPercentage = createCommand.LocationPercentage;
            
            BookHighlightId = Guid.NewGuid();
            CreatedAtUtc = DateTime.UtcNow;
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}
