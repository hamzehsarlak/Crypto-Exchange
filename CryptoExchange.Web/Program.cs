using CryptoExchange.Application.ExchangeRatesApi;
using CryptoExchange.Application.TaskScheduler;
using CryptoExchange.CoinMarketCap;
using CryptoExchange.Core.FluentValidation;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Core.Newtonsoft;
using CryptoExchange.Core.RestSharp;
using CryptoExchange.Data.InMemory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Newtonsoft.Json;
using CryptoExchange.Web;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.GetSection("CryptoExchangeConfig").Get<AppSettings>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configs
            
builder.Services.AddNewtonSerializer(options =>
{
    options.JsonSerializerSettings = new JsonSerializerSettings();
});
builder.Services.AddRestSharpBus(options =>
{
    options.MaxRetryAttempts = 2;
    options.PauseBetweenFailures = TimeSpan.FromSeconds(0);
});
builder.Services.AddMediatR();
builder.Services.AddAllMediatRHandlers();
builder.Services.AddAllValidators();

builder.Services.AddInMemoryRepository();

builder.Services.AddCoinMarketCap(options =>
{
    options.ApiKey = settings.CoinMarketCapApiKey;
});
builder.Services.AddExchangeRatesApi(options =>
{
    options.ApiKey = settings.ExchangeRatesApiKey;
});

builder.Services.AddHangFireTaskScheduler();
            
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
});
            
builder.Services.AddSignalR();
            
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

await app.UseHangFireTaskScheduler(options =>
{
    options.ListingApiMonthlyRequestLimit = settings.CoinMarketCapMonthlyLimit;
    options.RateApiMonthlyRequestLimit = settings.ExchangeRatesApiMonthlyLimit;
});

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapClientHub();
app.Run();