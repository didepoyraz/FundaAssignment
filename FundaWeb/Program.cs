using FundaWeb.Services;
using FundaWeb.Policies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddHttpClient<IFundaService, FundaService>()
    .AddPolicyHandler(RetryPolicy.GetFundaRetryPolicy());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "Welcome to Dide's Funda Assignment! \n--------------\n To see top 10 real estate agents with most listings for sale, go to the api/makelaars endpoint! \n--------------\n To see top 10 real estate agents with the most listings for sale with gardens go to api/makelaars/tuin endpoint!");

app.Run();
