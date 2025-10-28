using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopifyApi.Data;
using ShopifyAPI.model;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopifyConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Shopify API",
        Version = "v1",
        Description = "A simple Minimal API for managing products in my own Shopify Store.",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/Getall", async (AppDbContext db) =>
    await db.Products.ToListAsync())
    .WithSummary("Gets all products")
    .WithDescription("Retrieves all product records from the Shopify store.")
    .Produces<List<ProductModel>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/Add", async (AppDbContext db, ProductModel product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{product.Id}", product);
})
.WithSummary("Adds a new product")
.WithDescription("Creates a new product record and stores it in the database.")
.Produces<ProductModel>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);


app.Run();
