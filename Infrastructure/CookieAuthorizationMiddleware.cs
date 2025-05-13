using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Infrastructure
{
    public class CookieAuthorizationMiddleware(RequestDelegate nextDelegate)
    {
        private RequestDelegate next = nextDelegate;
        private List<string> ProtectedRoutes = ["/Store/Game", "/Store/Games", "/Store/Seller", "/Store/Sellers", "/Store/Publisher", "/Store/Publishers"];

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value ?? "/";
            
            if (path.StartsWith("/_blazor") ||
                path.EndsWith(".dll") || path.EndsWith(".blat") ||
                path.EndsWith(".js") || path.EndsWith(".css") ||
                path.EndsWith(".json") || path.StartsWith("/_framework"))
            {
                await next(context);
                return;
            }

            if (path != null
                && ProtectedRoutes.Find(x => path.StartsWith(x, StringComparison.OrdinalIgnoreCase)) != null)
            {
                (bool, string?) Authorized = CookieAuthorization.AuthorizedAccount(context.Request.Cookies["User"], null);
                if(!Authorized.Item1)
                {
                    context.Response.Cookies.Append("RedirectMessage", Authorized.Item2!, new CookieOptions
                    {
                        Path = "/Store/SignIn",
                        MaxAge = TimeSpan.FromMinutes(1),
                        HttpOnly = true
                    });

                    context.Response.Cookies.Append("ReturnUrl", path, new CookieOptions
                    {
                        Path = "/Store/SignIn",
                        MaxAge = TimeSpan.FromMinutes(1),
                        HttpOnly = true
                    });
                    context.Response.Redirect("/Store/SignIn");
                    return;
                }
            }
            await next(context);
        }
    }
}
