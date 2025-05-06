using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.DTOs;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Area("Store")]
    public class PublisherController(StoreContext context) : Controller
    {
        private StoreContext Context = context;
        public int PageSize = 10;

        public async Task<IActionResult> Index(int listPage)
        {
            List<Publisher> publisherList = await  Context.Publisher.Include(x => x.Games).OrderBy(x => x.PublisherId).Skip((listPage - 1) * PageSize).Take(PageSize).ToListAsync();
            List<PublisherDTO> DTOs = publisherList.Select(publisher => new PublisherDTO() 
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                GameCount = publisher.Games!.Count,
            }).ToList();

            return View(new PublisherListViewModel()
            {
                Publishers = DTOs,
                PagingInfo = new()
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = Context.Publisher.Count()
                }
            });
        }
    }
}
