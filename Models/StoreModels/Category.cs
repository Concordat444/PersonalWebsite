namespace PersonalWebsite.Models.StoreModels
{
    public class Category
    {
        public long CategoryID { get; set; }
        public required string Name { get; set; }

        public IEnumerable<Game>? Games { get; set; }
    }
}
