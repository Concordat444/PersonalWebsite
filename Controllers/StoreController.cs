using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;

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

        public IActionResult Index(string? gameCategory = "all")
        {
            if(gameCategory != "all")
            {
                long categoryId = -1;
                categoryId = Categories.FirstOrDefault(c => c.Name == gameCategory)?.CategoryID ?? -1;
                if (categoryId != -1)
                {
                    return View(context.Games.Where<Game>(c => c.CategoryId == categoryId).Include(g => g.Category).Include(g => g.ProductOwner));
                } else
                {
                    Response.Redirect("/Store");
                }
            }
            return View(context.Games.Include(g => g.Category).Include(g => g.ProductOwner));
        }
    }
}
