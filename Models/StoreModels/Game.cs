using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebsite.Models.StoreModels
{
    public class Game
    {
        public long GameId { get; set; }

        public required string Name { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public long CategoryId { get; set; }
        public Category? Category { get; set; }

        public long OwnerId { get; set; }
        public ProductOwner? ProductOwner { get; set; }
    }
}
