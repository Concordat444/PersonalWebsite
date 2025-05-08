using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalWebsite.Infrastructure
{
    public static class CookieAuthorization
    {
        public static (bool valid, string? error) AuthorizedAccount(string? username, List<string>? valid)
        {
            if (username == null)
            {
                return (false, "Please sign in as \"admin\" to view this page");
            }
            List<string> users = valid ?? ["admin"];
            return users.Contains(username) 
                ? (true, null) 
                : (false, $"The current user, \"{username}\", is not authorized to view this page. To view this page, please sign in as \"admin\".");
        }

        public static IActionResult RedirectToSignIn(HttpContext context, string? message)
        {
           return new RedirectToPageResult("/Store/SignIn", new { message = message });
        }
    }
}
