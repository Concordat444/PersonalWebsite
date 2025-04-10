using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebsite.Models.StoreModels
{
    public class Game
    {
        public long GameId { get; set; }

        public required string Name { get; set; }
        public string GameDescription { get; set; } = string.Empty;
        public int PublicationYear { get; set; }

        public long ProductId { get; set; }
        public IEnumerable<Product>? Products { get; set; }

        public long CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<PublisherGame> PublisherGames { get; set; } = [];
    }
}
