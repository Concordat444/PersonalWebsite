namespace PersonalWebsite.Models.StoreModels
{
    public class Publisher
    {
        public long PublisherId { get; set; }
        public string PublisherName { get; set; } = string.Empty;

        public List<Game>? Games { get; set; }

        //public List<PublisherGame> PublisherGames { get; set; } = [];
    }
}
