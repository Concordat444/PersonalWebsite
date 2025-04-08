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
        public int PageSize = 5;

        public StoreController(StoreContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string? gameCategory, int listPage = 1)
        {
            return View(new StoreListViewModel
            {
                Games = context.Games.Include(g => g.Category).Include(g => g.ProductOwner)
                    .Where(g => gameCategory == null ||  g.Category.Name == gameCategory)
                    .Skip((listPage - 1) * PageSize).Take(PageSize)
                    .OrderBy(g => g.GameId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = (gameCategory == null)
                        ? context.Games.Count()
                        : context.Games.Where(g => g.Category.Name == gameCategory).Count()
                },
                CurrentCategory = gameCategory
            });
        }
    }
}
