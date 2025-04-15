namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public static class ProductViewModelFactory
    {
        public static ProductViewModel Details(Product product)
        {
            return new ProductViewModel
            {
                Product = product,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                Categories = product == null || product.Category == null
                    ? Enumerable.Empty<Category>()
                    : [product.Category],
                Games = product == null || product.Game == null
                    ? []
                    : [product.Game]
            };
        }
    }
}
