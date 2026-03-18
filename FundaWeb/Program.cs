using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// The app now knows how to create http clients for calling external APIs
builder.Services.AddHttpClient<IFundaService, FundaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello Funda");

// app.MapGet("test-funda", async (IHttpClientFactory httpClientFactory) =>
// {
//     var client = httpClientFactory.CreateClient();

//     var url = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/76666a29898f491480386d966b75f949/?type=koop&zo=/amsterdam/&page=1&pagesize=25";

//     var response = await client.GetAsync(url);

//     if (!response.IsSuccessStatusCode)
//     {
//         return Results.Problem($"Funda API returned status code {response.StatusCode}");
//     }

//     var content = await response.Content.ReadAsStringAsync();
//     var document = JsonDocument.Parse(content);
//     var objects = document.RootElement.GetProperty("Objects");
//     var makelaars = new List<string>();

//     foreach (var item in objects.EnumerateArray())
//     {
//         var makelaar = item.GetProperty("MakelaarNaam").GetString();
//         makelaars.Add(makelaar);
//     }

//     return Results.Ok(makelaars);
// });
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
