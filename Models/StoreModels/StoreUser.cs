using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebsite.Models.StoreModels
{
    public class StoreUser
    {
        public long StoreUserId { get; set; }
        [RegularExpression("^[a - zA - Z0 - 9_.-]{3, 20}$")]
        public required string UserName { get; set; }
    }
}
