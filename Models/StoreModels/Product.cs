using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebsite.Models.StoreModels
{
    public class Product
    {
        public long ProductId { get; set; }
        public required string Name { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string SellerDescription { get; set; } = string.Empty;

        public long GameId { get; set; }
        public required Game Game { get; set; }

        public long OwnerId { get; set; }
        public ProductOwner? ProductOwner { get; set; }
    }
}
