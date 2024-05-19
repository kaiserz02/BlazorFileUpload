using BlazorFileUpload.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BlazorFileUpload.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TransactionController(AppDbContext context) {
            _context = context;
        }

        [HttpGet("bySymbol")]
        public async Task<ActionResult<List<Transaction>>> GetItemsBySymbol(string symbol) {
            try
            {
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
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "Internal server error: " + ex.Message });
            }
        }

        [HttpGet("byOrderSide")]
        public async Task<IActionResult> GetItemsByOrderSide(string orderSide) {
            try
            {
                var transactions = await _context.Transactions
                .Where(t => t.OrderSide == orderSide)
                .ToListAsync();

                if (transactions.Any())
                {
                    return Ok(transactions);
                }
                else
                {
                    return NotFound(new { StatusCode = 404, Message = "No data found for order side: " + orderSide });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "Internal server error: " + ex.Message });
            }
        }
        [HttpGet("byOrderStatus")]
        public async Task<IActionResult> GetItemsByOrderStatus(string orderStatus) {
            try
            {
                var transactions = await _context.Transactions
                .Where(t => t.OrderStatus == orderStatus)
                .ToListAsync();

                if (transactions.Any())
                {
                    return Ok(transactions);
                }
                else
                {
                    return NotFound(new { StatusCode = 404, Message = "No data found for order status: " + orderStatus });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "Internal server error: " + ex.Message });
            }
        }
        [HttpGet("byDateRange")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetItemsByDateRange([FromQuery] string startDate, [FromQuery] string endDate) {
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                return BadRequest("Start date and end date are required");
            }

            if (!DateTimeOffset.TryParseExact(startDate, "dd/MM/yyyyTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTimeOffset startDateTime) ||
                !DateTimeOffset.TryParseExact(endDate, "dd/MM/yyyyTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTimeOffset endDateTime))
            {
                return BadRequest("Invalid date format. Use dd/MM/yyyy HH:mm:ss (UTC)");
            }

            var transactions = await _context.Transactions
                .Where(t => t.TransactionDate >= startDateTime && t.TransactionDate <= endDateTime)
                .ToListAsync();

            return Ok(transactions);
        }
    }
}

