using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Infrastructure;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Area("Store")]
    public class SellerController(StoreContext context) : Controller
    {
        private readonly StoreContext Context = context;
        public int PageSize = 10;


        public IActionResult Index(int listPage)
        {
            return View(new SellerListViewModel 
            {
                ProductOwners = Context.ProductOwners
                .Include(p => p.Products)
                .Skip((listPage - 1) * PageSize).Take(PageSize)
                .OrderBy(p => p.ProductOwnerId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = Context.ProductOwners.Count()
                }
            });
        }

        public async Task<IActionResult> Details(long id)
        {
            ProductOwner? owner = await Context.ProductOwners.FirstOrDefaultAsync(x => x.ProductOwnerId == id) ?? ProductOwner.CreateEmpty();
            return View("SellerEditor", SellerViewModelFactory.Details(owner));
        }

        public IActionResult Create()
        {
            return View("SellerEditor", SellerViewModelFactory.Create());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductOwner productOwner)
        {
            if(ModelState.IsValid)
            {
                Context.ProductOwners.Add(productOwner);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("SellerEditor", SellerViewModelFactory.Create());
        }

        public async Task<IActionResult> Edit(long id)
        {
            ProductOwner? owner = await Context.ProductOwners.FirstOrDefaultAsync(p => p.ProductOwnerId == id) ?? ProductOwner.CreateEmpty();
            return View("SellerEditor", SellerViewModelFactory.Edit(owner));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ProductOwner productOwner)
        {
            if(ModelState.IsValid)
            {
                productOwner.Products = default;
                Context.ProductOwners.Update(productOwner);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("SellerEditor", SellerViewModelFactory.Edit(productOwner));
        }

        public async Task<IActionResult> Delete(long id)
        {
            ProductOwner owner = await Context.ProductOwners.FirstOrDefaultAsync(p => p.ProductOwnerId == id) ?? ProductOwner.CreateEmpty();
            return View("SellerEditor", SellerViewModelFactory.Delete(owner));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductOwner productOwner)
        {
            Context.ProductOwners.Remove(productOwner);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
