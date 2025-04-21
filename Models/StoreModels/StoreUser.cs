using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebsite.Models.StoreModels
{
    [Index(nameof(UserName), IsUnique = true)]
    public class StoreUser
    {
        public long StoreUserId { get; set; }
        [RegularExpression("^[a-zA-Z0-9_.-]{3, 20}$")]
        public required string UserName { get; set; }
        [RegularExpression("^(?=.*[\\W_]).{4,20}$")]
        public required string? Password { get; set; }
        public long? ProductOwnerId { get; set; }
        public ProductOwner? ProductOwner { get; set; }
    }
}
