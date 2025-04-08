namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class StoreListViewModel
    {
        public IEnumerable<Game>? Games { get; set; } = Enumerable.Empty<Game>();
        public IEnumerable<ProductOwner>? ProductOwners { get; set; } = Enumerable.Empty<ProductOwner>();
        public IEnumerable<Category>? Categories { get; set; } = Enumerable.Empty<Category>();
        public string? User { get; set; }
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public string? CurrentCategory { get; set; }
    }
}
