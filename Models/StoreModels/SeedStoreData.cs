using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.Models.StoreModels
{
    public static class SeedStoreData
    {
        public static void SeedDatabase(StoreContext context)
        {
            context.Database.Migrate();
            if (context.Games.Count() == 0
                    && context.ProductOwners.Count() == 0
                    && context.Categories.Count() == 0)
            {
                ProductOwner po1 = new ProductOwner
                {
                    FirstName = "John",
                    LastName = "Doe",
                    City = "Atlanta"
                };
                ProductOwner po2 = new ProductOwner
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    City = "Los Angeles"
                };

                Category c1 = new Category
                {
                    Name = "Ancient"
                };
                Category c2 = new Category
                {
                    Name = "Napoleonic"
                };
                Category c3 = new Category
                {
                    Name = "WW2"
                };

                Publisher AvalonHill = new Publisher
                {
                    PublisherName = "The Avalon Hill Game Co"
                };
                Publisher ValleyGames = new Publisher
                {
                    PublisherName = "Valley Games, Inc."
                };

                context.Games.AddRange(
                    new Game 
                    { 
                        Name = "Hannibal: Rome vs. Carthage",
                        Category = c1,

                        GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                    },

                    );
                context.SaveChanges();
            }
        }
    }
}
