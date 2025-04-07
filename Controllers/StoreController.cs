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
        public StoreController(StoreContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Games.Include(g => g.Category).Include(g => g.ProductOwner));
        }
    }
}
