public interface IQuoteRepository
{
    Task SaveAsync(IEnumerable<Quote> quotes);
}
