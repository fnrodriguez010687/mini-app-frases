public class QuoteScraper : IQuoteScraper
{
    private readonly HttpClient _http;

    public QuoteScraper(HttpClient http) => _http = http;

    public async Task<IEnumerable<Quote>> ScrapeFirstPageAsync()
    {
        // 1. GET /login, extraer csrf_token
        var loginPage = await _http.GetStringAsync("https://quotes.toscrape.com/login");
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(loginPage);
        var token = doc.DocumentNode
            .SelectSingleNode("//input[@name='csrf_token']")
            .GetAttributeValue("value", "");

        // 2. POST credenciales
        var form = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("csrf_token", token),
            new KeyValuePair<string, string>("username", "user"),
            new KeyValuePair<string, string>("password", "pass")
        });
        await _http.PostAsync("https://quotes.toscrape.com/login", form);

        // 3. GET página principal
        var home = await _http.GetStringAsync("https://quotes.toscrape.com/");
        doc.LoadHtml(home);

        // 4. Parsear quotes
        var nodes = doc.DocumentNode.SelectNodes("//div[@class='quote']");
        return nodes.Select(node => new Quote
        {
            Text = node.SelectSingleNode(".//span[@class='text']").InnerText.Trim(),
            Author = node.SelectSingleNode(".//small[@class='author']").InnerText.Trim(),
            Tags = node.SelectNodes(".//a[@class='tag']")
                       .Select(t => t.InnerText.Trim())
                       .ToList()
        });
    }
}

