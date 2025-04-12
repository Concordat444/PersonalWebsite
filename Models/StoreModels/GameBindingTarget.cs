using System.ComponentModel.DataAnnotations;

namespace PersonalWebsite.Models.StoreModels
{
    public class GameBindingTarget()
    {
        [Required]
        public required string Name { get; set; }
        public string GameDescription { get; set; } = string.Empty;
        public int PublicationYear { get; set; } = -1;
        public string ImageLink { get; set; } = string.Empty;
        public List<long> ProductIds { get; set; } = [];
        public List<long> PublisherIds { get; set; } = [];
        public long CategoryId { get; set; } = 4;
    }
}
