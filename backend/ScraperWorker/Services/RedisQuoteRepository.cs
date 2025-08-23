using System.Text.Json;
using StackExchange.Redis;

public class RedisQuoteRepository : IQuoteRepository
{
    private readonly IDatabase _db;
    private const string Key = "quotes:firstpage";

    public RedisQuoteRepository(IConnectionMultiplexer mux) => _db = mux.GetDatabase();

    public async Task SaveAsync(IEnumerable<Quote> quotes)
    {
        var json = JsonSerializer.Serialize(quotes);
        await _db.StringSetAsync(Key, json, TimeSpan.FromMinutes(5));
    }
}
