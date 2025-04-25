namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class SellerListViewModel
    {
        public IEnumerable<ProductOwner> ProductOwners { get; set; } = [];
        public PagingInfo PagingInfo { get; set; } = new();
    }
}
