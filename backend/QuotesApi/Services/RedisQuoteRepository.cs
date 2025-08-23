using System.Text.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    public async Task<IEnumerable<Quote>> GetAsync()
    {
        var redisValue  = await _db.StringGetAsync(Key);
        if (!redisValue.HasValue) return Enumerable.Empty<Quote>();

        string json = redisValue.ToString();
        if(string.IsNullOrEmpty(json)) return Enumerable.Empty<Quote>();
        var quotes = JsonSerializer.Deserialize<List<Quote>>(json);
        return quotes ?? Enumerable.Empty<Quote>();
    }
}
