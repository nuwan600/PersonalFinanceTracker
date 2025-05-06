using PFT.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Application.Contracts.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
        Task<TransactionDto> GetTransactionByIdAsync(int id);
        Task<TransactionDto> AddTransactionAsync(TransactionDto transactionDto);
        Task UpdateTransactionAsync(int id, TransactionDto transactionDto);
        Task DeleteTransactionAsync(int id);
        Task<TransactionSummaryDto> GetTransactionSummaryAsync();
    }
}
