using Application.Contract;
using Application.Features.Categories.Queries.FilterCategories;
using ECommerceDbContext;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add Connection String with Depndancy Injection (Singleton)

builder.Services.AddDbContext<ECommerce_DbContext>(options =>
{
    // Using Entity Framework Core Lazy Loading to not including objects / Lists / Collection when load data
    // options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnectionString"));
});
builder.Services.AddMediatR(config =>
config.RegisterServicesFromAssemblies(typeof(FiltersCategoriesQuery).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(FiltersCategoriesQuery).Assembly);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Index");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
