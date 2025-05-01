using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.Models.StoreModels.DTOs
{
    public class GameDTO
    {
        public long GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? GameDescription { get; set; }
        public int PublicationYear { get; set; }
        public string? ImageLink { get; set; }
        public required long CategoryId { get; set; }
        public required List<long> PublisherIds { get; set; }

        public static GameDTO GameToDTO (Game input)
        {
            return new()
            {
                GameId = input.GameId,
                Name = input.Name,
                GameDescription = input.GameDescription,
                PublicationYear = input.PublicationYear,
                ImageLink = input.ImageLink,
                CategoryId = input.CategoryId,
                PublisherIds = input.Publishers!.Select(x => x.PublisherId).ToList()
            };
        }

        public async Task<Game> DTOToGame(StoreContext context)
        {
            return new()
            {
                GameId = this.GameId,
                Name = this.Name,
                GameDescription = this.GameDescription ?? string.Empty,
                PublicationYear = this.PublicationYear,
                ImageLink = this.ImageLink ?? string.Empty,
                CategoryId = this.CategoryId,
                Category = await context.Categories.FindAsync(this.CategoryId),
                Publishers = await context.Publisher.Where(x => this.PublisherIds.Contains(x.PublisherId)).ToListAsync()
            };
        }
    }
}
