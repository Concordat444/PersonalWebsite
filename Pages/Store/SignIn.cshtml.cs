using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalWebsite.Pages.Store
{
    public class SignInModel : PageModel
    {
        public string ReturnUrl { get; set; } = "/Store";
        public string? Account { get; set; }
        
        public void OnGet()
        {
            Account = Request.Cookies["Account"];
        }

        public void OnPost([FromForm]string? acctName)
        {
            if (Account == null && (acctName != null || acctName == ""))
            {
                HttpContext.Response.Cookies.Append("Account", acctName);
            }
            else if (Account == null && (acctName == null || acctName == ""))
            {
                HttpContext.Response.Cookies.Append("Account", "Guest");
            }
            else
            {
                HttpContext.Response.Cookies.Delete("Account");
            }
            HttpContext.Response.Redirect(ReturnUrl);
        }
    }
}
