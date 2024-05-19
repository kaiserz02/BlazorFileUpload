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

    }
}
