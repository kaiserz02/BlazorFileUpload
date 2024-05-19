using BlazorFileUpload.Model;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
namespace BlazorFileUpload.Services
{
    public class TransactionFileService
    {
        private readonly HttpClient _httpClient;
        public TransactionFileService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<List<Transaction>> GetItemsBySymbol(string symbol) {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/transaction/bySymbol?symbol={symbol}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching transactions by symbol: {ex.Message}");
                return new List<Transaction>();
            }
        }
        public async Task<List<Transaction>> GetItemsByOrderSide(string orderSide) {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/transaction/byOrderSide?orderSide={orderSide}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching transactions by order side: {ex.Message}");
                return new List<Transaction>();
            }
        }
        public async Task<List<Transaction>> GetItemsByOrderStatus(string orderStatus) {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/transaction/byOrderStatus?orderStatus={orderStatus}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching transactions by order status: {ex.Message}");
                return new List<Transaction>();
            }
        }
        public async Task<IEnumerable<Transaction>> GetItemsByDateRange(string startDate, string endDate) {
            var response = await _httpClient.GetAsync($"api/transactions/byDateRange?startDate={Uri.EscapeDataString(startDate)}&endDate={Uri.EscapeDataString(endDate)}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<Transaction>>();
            return result;
        }
    }
}
