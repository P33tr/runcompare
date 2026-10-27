
// based on https://github.com/TDMR87/MARCH/blob/main/src/March.Web/Program.cs
// and this one https://www.bensampica.com/blog/minimalapihtmx/#introduction
using runcompare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddRazorComponents();

//===================================
//    BUILD
//===================================
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Redirect HTTP requests to HTTPS to ensure secure communication
app.UseHttpsRedirection();

// Map and serve static web assets
app.MapStaticAssets();

Api.AddRoutes(app);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
