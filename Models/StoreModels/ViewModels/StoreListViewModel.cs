namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class StoreListViewModel
    {
        public IEnumerable<Product>? Products { get; set; } = Enumerable.Empty<Product>();
        public IEnumerable<ProductOwner>? ProductOwners { get; set; } = Enumerable.Empty<ProductOwner>();
        public IEnumerable<Category>? Categories { get; set; } = Enumerable.Empty<Category>();
        public string? User { get; set; }
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public string? CurrentCategory { get; set; }
    }
}
