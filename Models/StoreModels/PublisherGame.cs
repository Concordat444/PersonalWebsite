namespace PersonalWebsite.Models.StoreModels
{
    public class PublisherGame
    {
        public long PublisherId { get; set; }
        public long GameId { get; set; }
        public Publisher Publisher { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}
