using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Components.Store
{
    public class AdminNavMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedRoute = HttpContext.GetRouteValue("Controller");
            return View();
        }
    }
}
