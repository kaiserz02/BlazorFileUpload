using BlazorFileUpload.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlazorFileUpload.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetItemsBySymbol")]
        public async Task<ActionResult<List<Transaction>>> GetItemsBySymbol(string symbol) {
            var transactions = await _context.Transactions
                .Where(t => t.Symbol == symbol)
                .ToListAsync();

            if (transactions.Any())
            {
                return Ok(transactions);
            }
            else
            {
                return NotFound(new { StatusCode = 404, Message = "No data found for symbol: " + symbol });
            }
        }
    }
}
