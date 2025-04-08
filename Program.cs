using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models;
using Microsoft.AspNetCore.Identity;
using PersonalWebsite.Models.StoreModels;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StoreContext>(options =>
    {
        options.UseSqlServer(builder.Configuration[
            "ConnectionStrings:DevGameConnection"
            ]);
        options.EnableSensitiveDataLogging(true);
    });
}

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(opts =>
{
    opts.CheckConsentNeeded = context => true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapControllers();
app.MapControllerRoute("Store", "{controller=Store}/{action=Index}");
app.MapControllerRoute("Pages", "Store/Page{listPage}", new { Controller = "Store", Action = "Index", listPage = 1 });
app.MapControllerRoute("Categories", "Store/{gameCategory}", new { Controller = "Store", Action = "Index" });
app.MapControllerRoute("CatPage", "Store/{gameCategory}/Page{listPage}", new { Controller = "Store", Action = "Index", listPage = 1 });

if (app.Environment.IsDevelopment())
{
    var storeContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<StoreContext>();
    SeedStoreData.SeedDatabase(storeContext);
}
app.Run();
