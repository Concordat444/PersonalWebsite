namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class SellerViewModel
    {
        public ProductOwner ProductOwner { get; set; } = ProductOwner.CreateEmpty();
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
    }
}
