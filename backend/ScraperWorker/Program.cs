using ScraperWorker;
using StackExchange.Redis;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddHttpClient<IQuoteScraper, QuoteScraper>(client =>
{
    client.BaseAddress = new Uri("https://quotes.toscrape.com/");
});


builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
    ConnectionMultiplexer.Connect("redis:6379"));

builder.Services.AddSingleton<IQuoteRepository, RedisQuoteRepository>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
await host.RunAsync();
