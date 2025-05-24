using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THADotNetTrainingBatch1.Database.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(otp =>
{
    otp.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/api/Products", ([FromServices] AppDbContext db) =>
{
    return Results.Ok(db.TblProducts.ToList());
});
app.Run();

app.MapGet("/api/Product/{id}", ([FromServices] AppDbContext db , int id) =>
{
    var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id );
    if(item is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(item);
});

app.MapPost("/api/Product/{id}", ([FromServices] AppDbContext db , [FromBody] ProductRequestModel requestModel) => 
    {
        var item = new TblProduct
        {
            CreateDateTime = DateTime.Now,
            CreatedBy = 1,
            Price = requestModel.Price,
            ProductCategory = requestModel.ProductCategory,
            ProductCode = requestModel.ProductCode!,
            ProductName = requestModel.ProductName!,
            Quantity = requestModel.Quantity
        };
    db.Add(item);
        db.SaveChanges();
});
internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal class ProductRequestModel
{
    public string? ProductCode { get; set; }    

    public string? ProductName { get; set; }    = null;

    public string? ProductCategory { get; set; } 

    public decimal Price { get; set; }      

    public int Quantity { get; set; }   
}
