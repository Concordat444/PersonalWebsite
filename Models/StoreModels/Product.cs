using Microsoft.EntityFrameworkCore;
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

        public long CategoryId { get; set; }
        public Category? Category { get; set; }

        /*GameId should not be nullable. This is a temporary solution to an EFCore error warning about possible deletion cascade if it is used as a foreign key.*/
        public long? GameId { get; set; }
        public Game? Game { get; set; }

        public long OwnerId { get; set; }
        public ProductOwner? ProductOwner { get; set; }
    }
}
