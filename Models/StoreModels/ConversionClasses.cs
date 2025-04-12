namespace PersonalWebsite.Models.StoreModels
{
    public static class ConversionClasses
    {
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
