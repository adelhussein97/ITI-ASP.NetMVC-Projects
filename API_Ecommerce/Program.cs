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
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(config => 
config.RegisterServicesFromAssemblies( typeof(FiltersCategoriesQuery).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(FiltersCategoriesQuery).Assembly);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//--------------------------------------------------------------
// Configuring Swagger OpenApi
// install Package Microsoft.AspNetCore.Open , Swashbuckle.AspNetCore
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--------------------------------------------------------------
var app = builder.Build();

// Environement Varible Status Development or Production
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Configure the HTTP request pipeline.
app.Run();

