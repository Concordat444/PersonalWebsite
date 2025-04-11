namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class StoreListViewModel
    {
        public IEnumerable<Product>? Products { get; set; } = [];
        public IEnumerable<ProductOwner>? ProductOwners { get; set; } = [];
        public IEnumerable<Category>? Categories { get; set; } = [];
        public string? User { get; set; }
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public string? CurrentCategory { get; set; }
    }
}
