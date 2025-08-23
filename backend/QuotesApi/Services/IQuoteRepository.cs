public interface IQuoteRepository
{
    Task SaveAsync(IEnumerable<Quote> quotes);
    Task<IEnumerable<Quote>> GetAsync();
}
