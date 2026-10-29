using Microsoft.AspNetCore.Http.HttpResults;
using runcompare.Features.Shared;

namespace runcompare;

public static class Pages
{
    
    public static void AddRoutes( WebApplication app)
    {
        app.MapGet("/", () => new RazorComponentResult<Home>()); 

    }
}