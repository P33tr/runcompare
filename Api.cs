using System.Runtime.InteropServices.ComTypes;

namespace runcompare;

public static class Api
{
    
    public static void AddRoutes( WebApplication app)
    {
        IResult Render(string html)
        {
            return html;
        }
        app.MapGet("/health", () =>
        {
            
            string html = "<html><body><h1>OK</h1></body></html>";
            return Render(html);
        });
        
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        app.MapGet("/weatherforecast", () =>
            {
                var forecast =  Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");
    }
}