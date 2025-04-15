using System.ComponentModel.DataAnnotations;

namespace PersonalWebsite.Models.StoreModels
{
    public class PublisherBindingTarget
    {
        public long? Id { get; set; }
        [Required]
        public required string PublisherName { get; set; }
        public List<long>? GameIds { get; set; }
    }
}
