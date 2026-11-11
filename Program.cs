using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Wijha.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WijhaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "customer";
})
.AddCookie("customer", options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.Cookie.Name = ".Wijha.Customer";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/";
})
.AddCookie("provider", options =>
{
    options.LoginPath = "/provider/login";
    options.LogoutPath = "/provider/logout";
    options.Cookie.Name = ".Wijha.Provider";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/provider/login";
})
.AddCookie("admin", options =>
{
    options.LoginPath = "/admin/login";
    options.LogoutPath = "/admin/logout";
    options.Cookie.Name = ".Wijha.Admin";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = false;
    options.AccessDeniedPath = "/admin/login";
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
