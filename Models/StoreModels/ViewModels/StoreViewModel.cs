namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class StoreViewModel
    {
        public IEnumerable<Game>? Games { get; set; }
        public IEnumerable<ProductOwner>? ProductOwners { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public string? User { get; set; }
    }
}
