namespace PersonalWebsite.Models.StoreModels.APIOutputs
{
    public class PublisherOutput
    {
        public long? PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public Dictionary<long, string>? Games { get; set; }

        public PublisherOutput PublisherToPublisherOutput(Publisher publisher)
        {
            return new PublisherOutput
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                Games = publisher.Games?.ToDictionary(x => x.GameId, y => y.Name) ?? []
            };
        }
    }
}
