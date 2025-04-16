using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;

namespace PersonalWebsite.Components.Store
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private StoreContext context;

        public NavigationMenuViewComponent(StoreContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["gameCategory"];
            return View
            (
                context.Products.Include(p => p.Game).ThenInclude(g => g!.Category)
                .Select(p => p.Game!.Category!.Name)
                .Distinct()
                .OrderBy(c => c)
            );
        }
    }
}
