namespace PersonalWebsite.Models.StoreModels.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;

        public int TotalPages => 
            (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
