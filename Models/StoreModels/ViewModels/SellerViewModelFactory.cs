namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public static class SellerViewModelFactory
    {
        public static SellerViewModel Details(ProductOwner productOwner)
        {
            return new()
            {
                Action = "Details",
                ProductOwner = productOwner,
                ReadOnly = true,
                Theme = "info",
                ShowAction = false                
            };
        }

        public static SellerViewModel Create()
        {
            return new();
        }

        public static SellerViewModel Edit(ProductOwner productOwner)
        {
            return new()
            {
                Action = "Edit",
                ProductOwner = productOwner,
                ReadOnly = false,
                Theme = "warning",
                ShowAction = true
            };
        }

        public static SellerViewModel Delete(ProductOwner productOwner)
        {
            return new()
            {
                Action = "Delete",
                ProductOwner = productOwner,
                ReadOnly = true,
                Theme = "danger",
                ShowAction = true
            };
        }
    }
}
