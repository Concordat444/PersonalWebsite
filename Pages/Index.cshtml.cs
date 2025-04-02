using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.Features;

namespace PersonalWebsite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public void OnGetCookie()
    {
        ITrackingConsentFeature? consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
        if (consentFeature != null)
        {
            if(!consentFeature.HasConsent)
            {
                consentFeature.GrantConsent();
            } else
            {
                consentFeature.WithdrawConsent();
            }
        }
        HttpContext.Response.Redirect("/");
    }
}
