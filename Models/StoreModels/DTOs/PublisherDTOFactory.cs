namespace PersonalWebsite.Models.StoreModels.DTOs
{
    public static class PublisherDTOFactory
    {
        public static PublisherDTO Mimimum(Publisher publisher)
        {
            return new()
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName
            };
        }

        public static PublisherDTO Count(Publisher publisher)
        {
            return new()
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                GameCount = publisher.Games?.Count ?? -1
            };
        }

        public static PublisherDTO Games(Publisher publisher)
        {
            return new()
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                GamesDict = publisher.Games?.ToDictionary(k => k.GameId, v => v.Name) ?? [],
                GameCount = publisher.Games?.Count ?? -1
            };
        }
    }
}
