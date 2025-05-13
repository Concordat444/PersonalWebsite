using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Area("Store")]
    public class HomeController(StoreContext context) : Controller
    {
        private readonly StoreContext context = context;
        private IEnumerable<ProductOwner> ProductOwners => context.ProductOwners;
        private IEnumerable<Game> Games => context.Games;
        public int PageSize = 5;
        int ProtectedEntries { get; } = 13;

        public IActionResult Index(string? gameCategory, int listPage = 1)
        {
            return View(new StoreListViewModel
            {
                Products = context.Products.Include(g => g.Game).Include(g => g.ProductOwner)
                    .Where(g => gameCategory == null ||  g.Game!.Category!.Name == gameCategory)
                    .Skip((listPage - 1) * PageSize).Take(PageSize)
                    .OrderBy(g => g.GameId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = gameCategory == null
                        ? context.Products.Count()
                        : context.Products.Where(g => g.Game!.Category!.Name == gameCategory).Count()
                },
                CurrentCategory = gameCategory
            });
        }

        public async Task<IActionResult> Details(long id)
        {
            Product? product = await context.Products
                .Include(p => p.Game).ThenInclude(c => c!.Category)
                .Include(p => p.Game).ThenInclude(g => g!.Publishers)
                .Include(p => p.ProductOwner)
                .FirstOrDefaultAsync(p => p.ProductId == id)
                ?? new() { Name = string.Empty };
            ProductViewModel model = ProductViewModelFactory.Details(product);
            return View("ProductEditor", model);
        }

        public IActionResult Create()
        {
            return View("ProductEditor", ProductViewModelFactory.Create
                (
                    new Product
                    {
                        Name = string.Empty
                    },
                    Games,
                    ProductOwners
                )
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = default;
                product.Game = default;
                product.ProductOwner = default;
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("ProductEditor", ProductViewModelFactory
                .Create(new Product { Name = string.Empty }, Games, ProductOwners));
        }

        public async Task<IActionResult> Edit(long id)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product != null)
            {
                ProductViewModel model = ProductViewModelFactory.Edit(product, Games, ProductOwners);
                return View("ProductEditor", model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId <= ProtectedEntries)
                {
                    string message =
                        $"The original {ProtectedEntries} entries are for demonstration purposes and should not be modified. To test CRUD features, please create a new entry to work on.";
                    TempData["Message"] = message;
                    TempData["MessageStyle"] = "info";

                    return RedirectToRoute("Pages");
                }
                product.Game = default;
                product.ProductOwner = default;
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return RedirectToRoute("Pages");
            }
            return View("ProductEditor", ProductViewModelFactory.Edit(product, Games, ProductOwners));
        }

        public async Task<IActionResult> Delete(long id)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product != null)
            {
                ProductViewModel model = ProductViewModelFactory.Delete(product, Games, ProductOwners);
                return View("ProductEditor" ,model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (product.ProductId <= ProtectedEntries)
            {
                string message =
                    $"The original {ProtectedEntries} entries are for demonstration purposes and should not be modified. To test CRUD features, please create a new entry to work on.";
                TempData["Message"] = message;
                TempData["MessageStyle"] = "info";

                return RedirectToRoute("Pages");
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToRoute("Pages");
        }
    }
}
