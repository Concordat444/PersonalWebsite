using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Controllers
{
    public class StoreController : Controller
    {
        private StoreContext context;
        private IEnumerable<Category> Categories => context.Categories;
        private IEnumerable<ProductOwner> ProductOwners => context.ProductOwners;
        private IEnumerable<Game> Games => context.Games;
        public int PageSize = 5;

        public StoreController(StoreContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string? gameCategory, int listPage = 1)
        {
            return View(new StoreListViewModel
            {
                Products = context.Products.Include(g => g.Game).Include(g => g.ProductOwner).OrderBy(g => g.GameId)
                    .Where(g => gameCategory == null ||  (g.Game!.Category!.Name == gameCategory))
                    .Skip((listPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = (gameCategory == null)
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
                return RedirectToRoute("Pages");
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
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToRoute("Pages");
        }
    }
}
