using PersonalWebsite.Models.StoreModels.DTOs;

namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class PublisherListViewModel
    {
        public IEnumerable<PublisherDTO> Publishers { get; set; } = [];
        public PagingInfo PagingInfo { get; set; } = new();
    }
}
