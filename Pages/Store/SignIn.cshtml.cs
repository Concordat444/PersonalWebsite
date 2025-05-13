using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalWebsite.Pages.Store
{
    public class SignInModel : PageModel
    {
        public string? ReturnUrl { get; set; } = "/Store";
        [TempData]
        public string? message { get; set; }
        public string? RedirectMessage { get; set; }
        public bool? CookiesActive { get; set; }
        public void OnGet()
        {
            if(Request.Cookies.TryGetValue("RedirectMessage", out var redirectMessage))
            {
                RedirectMessage = redirectMessage;
                Response.Cookies.Delete("RedirectMessage");
            }
            if(Request.Cookies.TryGetValue("ReturnUrl", out var returnUrl))
            {
                RedirectMessage = redirectMessage;
                Response.Cookies.Delete("ReturnUrl");
            }
            ReturnUrl = returnUrl;
            CookiesActive = Request.Cookies[".AspNet.Consent"] == "yes";
        }

        public  IActionResult OnPost() 
        {
            string? Username = Request.Form["Username"] == "" ? "Guest" : Request.Form["Username"];
            string returnUrl = Request.Form["returnUrl"].ToString() ?? "/Store";
            Response.Cookies.Append("User", Username!, new CookieOptions { MaxAge = TimeSpan.FromDays(2) });
            return Redirect(returnUrl);
        }

        public IActionResult OnGetAllow()
        {
            ITrackingConsentFeature? consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            if (consentFeature != null)
            {
                if (!consentFeature.HasConsent)
                {
                    consentFeature.GrantConsent();
                }
            }
            return ReturnUrl == null
                ? Redirect("/Store/SignIn")
                : RedirectToPage("/Store/SignIn");
        }

        public IActionResult OnGetSignOut()
        {
            Response.Cookies.Delete("User");
            return ReturnUrl == null
            ? RedirectToRoute("Pages")
            : Redirect(ReturnUrl);
        }
    }
}
