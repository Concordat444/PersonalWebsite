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
                    City = "Roswell"
                };

                Category c1 = new Category
                {
                    Name = "Classical Era"
                };
                Category c2 = new Category
                {
                    Name = "Napoleonic Wars"
                };
                Category c3 = new Category
                {
                    Name = "World War 2"
                };

                context.Games.AddRange(
                    new Game { Name = "Classical Game 1", Price = 50, Category = c1, ProductOwner = po1 },
                    new Game { Name = "Classical Game 2", Price = 50.50m, Category = c1, ProductOwner = po1 },
                    new Game { Name = "Classical Game 3", Price = 60, Category = c1, ProductOwner = po2 },
                    new Game { Name = "Napoleonic Game 1", Price = 75.99m, Category = c2, ProductOwner = po1 },
                    new Game { Name = "Napoleonic Game 2", Price = 90, Category = c2, ProductOwner = po2 },
                    new Game { Name = "Napoleonic Game 3", Price = 40, Category = c2, ProductOwner = po1 },
                    new Game { Name = "Napoleonic Game 4", Price = 80, Category = c2, ProductOwner = po2 },
                    new Game { Name = "WW2 Game 1", Price = 9.99m, Category = c3, ProductOwner = po2 },
                    new Game { Name = "WW2 Game 2", Price = 24.99m, Category = c3, ProductOwner = po1 },
                    new Game { Name = "WW2 Game 3", Price = 39.99m, Category = c3, ProductOwner = po2 },
                    new Game { Name = "WW2 Game 4", Price = 54.99m, Category = c3, ProductOwner = po1 },
                    new Game { Name = "WW2 Game 5", Price = 69.99m, Category = c3, ProductOwner = po2 },
                    new Game { Name = "WW2 Game 6", Price = 84.99m, Category = c3, ProductOwner = po1 }
                    );
                context.SaveChanges();
            }
        }
    }
}
