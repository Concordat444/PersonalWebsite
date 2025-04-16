namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; } = new() { Name = string.Empty };

        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
        public IEnumerable<Game> Games { get; set; } = [];
        public IEnumerable<ProductOwner> ProductOwners { get; set; } = [];
        public ProductOwner Owner { get; set; } = new() { City = string.Empty, EMail = string.Empty, FirstName = string.Empty, LastName= string.Empty, Username = string.Empty };
    }
}
