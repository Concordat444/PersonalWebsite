namespace PersonalWebsite.Models.StoreModels.DTOs
{
    public class PublisherDTO
    {
        public long? PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public int? GameCount { get; set; }
        public Dictionary<long, string>? GamesDict { get; set; }
    }
}
