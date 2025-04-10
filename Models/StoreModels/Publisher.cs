namespace PersonalWebsite.Models.StoreModels
{
    public class Publisher
    {
        public long PublisherId { get; set; }
        public string PublisherName { get; set; } = string.Empty;

        public List<PublisherGame> PublisherGames { get; set; } = [];
    }
}
