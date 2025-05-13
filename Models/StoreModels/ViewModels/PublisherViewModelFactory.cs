using PersonalWebsite.Models.StoreModels.DTOs;

namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public static class PublisherViewModelFactory
    {

        public static PublisherViewModel Details(Publisher publisher)
        {
            return new()
            {
                Publisher = new PublisherDTO()
                {
                    PublisherId = publisher.PublisherId,
                    PublisherName = publisher.PublisherName,
                },
                Action = "Details",
                ReadOnly = true,
                ShowAction = false,
                Theme = "info"
            };
        }

        public static PublisherViewModel Create()
        {
            return new();
        }

        public static PublisherViewModel Edit(Publisher publisher)
        {
            return new()
            {
                Publisher = new PublisherDTO()
                {
                    PublisherId = publisher.PublisherId,
                    PublisherName = publisher.PublisherName,
                },
                Action = "Edit",
                ReadOnly = false,
                ShowAction = true,
                Theme = "warning"
            };
        }

        public static PublisherViewModel Delete(Publisher publisher)
        {
            return new()
            {
                Publisher = new PublisherDTO()
                {
                    PublisherId = publisher.PublisherId,
                    PublisherName = publisher.PublisherName,
                },
                Action = "Delete",
                ReadOnly = true,
                ShowAction = true,
                Theme = "danger"
            };
        }
    }

}
