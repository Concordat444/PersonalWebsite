using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models;
using Microsoft.AspNetCore.Identity;
using PersonalWebsite.Models.StoreModels;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

string? connString = System.Environment.GetEnvironmentVariable("SQLCONNSTR_GameStoreDbConnection");
string testConnString = builder.Configuration["SQLCONNSTR"]!;

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StoreContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DevGameConnection"]);
        options.EnableSensitiveDataLogging(true);
    });
} else
{
    builder.Services.AddDbContext<StoreContext>(options =>
    {
        options.UseSqlServer(connString);
    });
}

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors();
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
app.UseMiddleware<CookieAuthorizationMiddleware>();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapControllers();

app.MapAreaControllerRoute("PublisherPages", "Store", "/Store/Publishers/Page{listPage:int}", new { Controller = "Publisher", Action = "Index", listPage = 1 });
app.MapAreaControllerRoute("SellerPages", "Store", "/Store/Sellers/Page{listPage:int}", new { Controller = "Seller", Action = "Index", listPage = 1 });
app.MapAreaControllerRoute("GamePages", "Store", "/Store/Games/Page{listPage:int}", new { Controller = "Game", Action = "Index", listPage = 1 });
app.MapAreaControllerRoute("Pages", "Store", "/Store/Page{listPage:int}", new {  Controller = "Home", Action = "Index", listPage = 1 });
app.MapAreaControllerRoute("Categories", "Store", "/Store/{gameCategory}", new { Controller = "Home", Action = "Index" });
app.MapAreaControllerRoute("CatPage", "Store", "/Store/{gameCategory}/Page{listPage:int}", new { Controller = "Home", Action = "Index", listPage = 1 });
app.MapControllerRoute("StoreArea", "{area:exists}/{controller=Home}/{action=Index}");

//if (app.Environment.IsDevelopment())
//{
var storeContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<StoreContext>();
SeedStoreData.SeedDatabase(storeContext);
//}
app.Run();
