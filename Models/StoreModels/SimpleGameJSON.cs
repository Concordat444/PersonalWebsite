namespace PersonalWebsite.Models.StoreModels
{
    public class SimpleGameJSON
    {
        public long GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public List<long> ProductIds { get; set; } = [];
        public string CategoryName { get; set; } = "Other";
        public List<string> Publishers { get; set; } = [];
    }
}
