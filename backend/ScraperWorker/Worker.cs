namespace ScraperWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IQuoteScraper _scraper;
    private readonly IQuoteRepository _repo;

    public Worker(ILogger<Worker> logger, IQuoteScraper scraper, IQuoteRepository repo)
    {
        _logger = logger;
        _scraper = scraper;
        _repo = repo;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            var quotes = await _scraper.ScrapeFirstPageAsync();
            await _repo.SaveAsync(quotes);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
