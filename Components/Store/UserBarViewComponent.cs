using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Infrastructure;

namespace PersonalWebsite.Components.Store
{
    public class UserBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (Request.Cookies["User"] != null)
            {
                ViewBag.User = Request.Cookies["User"];
            }
            ViewBag.ReturnUrl = UrlExtensions.PathAndQuery(Request);
            return View();
        }
    }
}
