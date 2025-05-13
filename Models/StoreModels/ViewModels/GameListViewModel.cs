namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class GameListViewModel
    {
        public IEnumerable<Game> Games { get; set; } = [];
        public PagingInfo PagingInfo { get; set; } = new();
        public string? Message { get; set; }
    }
}
