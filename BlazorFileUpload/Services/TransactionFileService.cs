using BlazorFileUpload.Model;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
namespace BlazorFileUpload.Services
{
    public class TransactionFileService
    {
        private readonly HttpClient _httpClient;
        public TransactionFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Transaction>> GetItemsBySymbol(string symbol) {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/transaction/GetItemsBySymbol?symbol={symbol}");
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
                return await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/transaction/GetItemsByOrderSide?orderSide={orderSide}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching transactions by orderSide: {ex.Message}");
                return new List<Transaction>();
            }
        }

    }
}
