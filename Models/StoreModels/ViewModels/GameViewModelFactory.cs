namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public static class GameViewModelFactory
    {
        public static GameViewModel Details(Game game)
        {
            return new()
            {
                Action = "Details",
                Game = game,
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                Categories = game == null || game.Category == null
                    ? []
                    : [game.Category],
                Publishers = game == null || game.Publishers == null
                    ? []
                    : game.Publishers
            };
        }

        public static GameViewModel Create(IEnumerable<Category> categories, List<Publisher> publishers)
        {
            return new() { Categories = categories, Publishers = publishers };
        }

        public static GameViewModel Edit(Game game, IEnumerable<Category> categories, List<Publisher> publishers)
        {
            return new()
            {
                Action = "Edit",
                Game = game,
                ReadOnly = false,
                Theme = "warning",
                ShowAction = true,
                Categories = categories,
                Publishers = publishers
            };
        }

        public static GameViewModel Delete(Game game, IEnumerable<Category> categories)
        {
            return new()
            {
                Action = "Delete",
                Game = game,
                ReadOnly = true,
                Theme = "danger",
                ShowAction = true,
                Categories= categories
            };
        }
    }
}
