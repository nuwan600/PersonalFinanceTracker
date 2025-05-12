using PFT.Web.Models;

namespace PFT.Web.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _httpClient;

        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Transaction>>("api/transactions");
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Transaction>($"api/transactions/{id}");
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync("api/transactions", transaction);
            return await response.Content.ReadFromJsonAsync<Transaction>();
        }

        public async Task UpdateTransactionAsync(int id, Transaction transaction)
        {
            await _httpClient.PutAsJsonAsync($"api/transactions/{id}", transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/transactions/{id}");
        }

        public async Task<TransactionSummary> GetTransactionSummaryAsync()
        {
            return await _httpClient.GetFromJsonAsync<TransactionSummary>("api/transactions/summary");
        }
    }
}
