using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Infrastructure;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.DTOs;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Area("Store")]
    public class PublisherController(StoreContext context) : Controller
    {
        private readonly StoreContext Context = context;
        public int PageSize = 10;
        int ProtectedEntries { get; } = 16;


        public async Task<IActionResult> Index(int listPage)
        {
            List<Publisher> publisherList = await  Context.Publisher.Include(x => x.Games).OrderBy(x => x.PublisherId).Skip((listPage - 1) * PageSize).Take(PageSize).ToListAsync();
            List<PublisherDTO> DTOs = [.. publisherList.Select(publisher => new PublisherDTO() 
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                GameCount = publisher.Games!.Count,
            })];

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

        public async Task<IActionResult> Details(long id)
        {
            Publisher publisher = await Context.Publisher.FirstOrDefaultAsync(x => x.PublisherId == id) ?? new();
            return View("PublisherEditor", PublisherViewModelFactory.Details(publisher));
        }

        public IActionResult Create()
        {
            return View("PublisherEditor", PublisherViewModelFactory.Create());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PublisherDTO publisher)
        {
            if(ModelState.IsValid)
            {
                Publisher Publisher = new()
                {
                    PublisherId = default,
                    PublisherName = publisher.PublisherName
                };
                Context.Publisher.Add(Publisher);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("PublisherEditor", PublisherViewModelFactory.Create());
        }

        public async Task<IActionResult> Edit(long id)
        {
            Publisher publisher = await Context.Publisher.FirstOrDefaultAsync(x => x.PublisherId == id) ?? new();
            return View("PublisherEditor", PublisherViewModelFactory.Edit(publisher));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] PublisherDTO publisher)
        {
            Publisher? Publisher = await Context.Publisher.FirstOrDefaultAsync(x => x.PublisherId == publisher.PublisherId);
            if (Publisher == null)
            {
                TempData["Message"] = "The item you are trying to edit cannot be found";
                TempData["MessageStyle"] = "danger";
                return RedirectToAction(nameof(Index));
            }
            Publisher.PublisherName = publisher.PublisherName;
            if (ModelState.IsValid)
            {
                if (Publisher.PublisherId <= ProtectedEntries)
                {
                    string message =
                        $"The original {ProtectedEntries} entries are for demonstration purposes and should not be modified. To test CRUD features, please create a new entry to work on.";
                    TempData["Message"] = message;
                    TempData["MessageStyle"] = "info";

                    return RedirectToAction(nameof(Index));
                }
                Context.Publisher.Update(Publisher);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("PublisherEditor", PublisherViewModelFactory.Edit(Publisher));
        }

        public async Task<IActionResult> Delete(long id)
        {
            Publisher? Publisher = await Context.Publisher.FirstOrDefaultAsync(x => x.PublisherId == id);
            if (Publisher == null)
            {
                TempData["Message"] = "The item you are trying to edit cannot be found";
                TempData["MessageStyle"] = "danger";
                return RedirectToAction(nameof(Index));
            }
            return View("PublisherEditor", PublisherViewModelFactory.Delete(Publisher));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] PublisherDTO publisher)
        {
            Publisher? Publisher = await Context.Publisher.FirstOrDefaultAsync(x => x.PublisherId == publisher.PublisherId);
            if (Publisher == null)
            {
                TempData["Message"] = "The item you are trying to edit cannot be found";
                TempData["MessageStyle"] = "danger";
                return RedirectToAction(nameof(Index));
            }
            if (Publisher.PublisherId <= ProtectedEntries)
            {
                string message =
                    $"The original {ProtectedEntries} entries are for demonstration purposes and should not be modified. To test CRUD features, please create a new entry to work on.";
                TempData["Message"] = message;
                TempData["MessageStyle"] = "info";
                return RedirectToAction(nameof(Index));
            }
            Context.Publisher.Remove(Publisher);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
