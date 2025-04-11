using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.Models.StoreModels
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
        //public DbSet<PublisherGame> PublisherGame => Set<PublisherGame>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductOwner> ProductOwners => Set<ProductOwner>();
        public DbSet<Product> Products => Set<Product>();
    }
}
