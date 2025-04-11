using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.Models.StoreModels
{
    [Keyless]
    public class PublisherGame
    {
        public long PublisherId { get; set; }
        public long GameId { get; set; }
        public Publisher Publisher { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}
