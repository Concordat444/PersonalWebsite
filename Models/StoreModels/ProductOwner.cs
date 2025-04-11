using System.ComponentModel.DataAnnotations;

namespace PersonalWebsite.Models.StoreModels
{
    public class ProductOwner
    {
        [Key]
        public long OwnerId { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
        public required string EMail { get; set; }

        public IEnumerable<Game>? Games { get; set; }
    }
}
