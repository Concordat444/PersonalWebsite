using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PersonalWebsite.Models.StoreModels
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(EMail), IsUnique = true)]
    public class ProductOwner
    {
        public long ProductOwnerId { get; set; }
        public required string Username { get; set; }
        [RegularExpression("^[a-zA-z]{1,20}$")]
        public required string FirstName { get; set; }
        [RegularExpression("^[a-zA-z-]{1,20}$")]
        public required string LastName { get; set; }
        [RegularExpression("^[a-zA-z-]{1,20}$")]
        public required string City { get; set; }
        [EmailAddress]
        public required string EMail { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        public static ProductOwner CreateEmpty()
        {
            return new ProductOwner()
            {
                Username = "",
                FirstName = "",
                LastName = "",
                City = "",
                EMail = ""
            };
        }
    }
}
