using PersonalWebsite.Models.StoreModels.DTOs;

namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class PublisherViewModel
    {
        public PublisherDTO Publisher { get; set; } = new() { PublisherName = string.Empty };
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
    }
}
