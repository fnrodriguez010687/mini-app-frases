using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IQuoteRepository _repo;
    public QuotesController(IQuoteRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Leer de Redis, máximo 500 ms
        
        var quotes = await _repo.GetAsync();
        if (quotes.Count() == 0) return NoContent();
        return Ok(quotes);
    }
}
