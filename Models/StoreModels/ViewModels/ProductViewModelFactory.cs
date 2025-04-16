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
                Games = product == null || product.Game == null
                    ? []
                    : [product.Game],
                ProductOwners = product == null || product.ProductOwner == null
                    ? []
                    : [product.ProductOwner]
            };
        }

        public static ProductViewModel Create(Product product, IEnumerable<Game> games, IEnumerable<ProductOwner> productOwners)
        {
            return new ProductViewModel
            {
                Product = product,
                ProductOwners = productOwners,
                Games = games
            };
        }

        public static ProductViewModel Edit(Product product, IEnumerable<Game> games, IEnumerable<ProductOwner> productOwners)
        {
            return new ProductViewModel
            {
                Product = product,
                ProductOwners = productOwners,
                Games = games,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static ProductViewModel Delete(Product product, IEnumerable<Game> games, IEnumerable<ProductOwner> productOwners)
        {
            return new ProductViewModel
            {
                Product = product,
                ProductOwners = productOwners,
                Games = games,
                Theme = "danger",
                Action = "Delete"
            };
        }
    }
}
