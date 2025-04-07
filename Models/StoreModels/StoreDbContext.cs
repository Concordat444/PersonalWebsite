using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.Models.StoreModels
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductOwner> ProductOwners => Set<ProductOwner>();
    }
}
