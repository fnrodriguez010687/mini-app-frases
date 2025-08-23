public interface IQuoteScraper
{
    Task<IEnumerable<Quote>> ScrapeFirstPageAsync();
}
