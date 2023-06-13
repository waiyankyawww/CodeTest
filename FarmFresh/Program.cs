using FarmFresh.DAL;
using FarmFresh.Models;
using FarmFresh.Models.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<FarmFreshContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Repo pattern
builder.Services.AddScoped<IProductRepository<Product>, ProductManager>();

// Configure Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<FarmFreshContext>()
    .AddDefaultTokenProviders();

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();

