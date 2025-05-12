using PFT.Web.Models;

namespace PFT.Web.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(int id, Transaction transaction);
        Task DeleteTransactionAsync(int id);
        Task<TransactionSummary> GetTransactionSummaryAsync();
    }
}
