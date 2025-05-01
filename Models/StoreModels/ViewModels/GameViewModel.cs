namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class GameViewModel
    {
        public Game Game { get; set; } = new() { Name = string.Empty, CategoryId = 4, Category = new() { CategoryID = 4, Name = "Other" } };
        public IEnumerable<Category>? Categories { get; set; } = [new() { Name = "Other", CategoryID = 4 }];
        public List<Publisher>? Publishers { get; set; }
        public List<long>? PublisherIds { get; set; }
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
    }
}
