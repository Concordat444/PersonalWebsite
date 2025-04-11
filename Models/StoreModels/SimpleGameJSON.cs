namespace PersonalWebsite.Models.StoreModels
{
    public class SimpleGameJSON
    {
        public long GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public List<long> ProductIds { get; set; } = [];
        public string CategoryName { get; set; } = "Other";
        public List<string> Publishers { get; set; } = [];

        public static SimpleGameJSON GameToSimpleGameJSON(Game game)
        {
            return new SimpleGameJSON
            {
                GameId = game.GameId,
                Name = game.Name,
                Description = game.GameDescription,
                PublicationYear = game.PublicationYear,
                ProductIds = game.Products != null ? game.Products.Select(p => p.ProductId).ToList() : [],
                CategoryName = game.Category?.Name ?? "Other",
                Publishers = game.Publishers != null ? game.Publishers.Select(p => p.PublisherName).ToList() : []
            };
        }
    }
}
