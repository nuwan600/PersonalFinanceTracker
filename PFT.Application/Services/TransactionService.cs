using AutoMapper;
using PFT.Application.Contracts.Persistence;
using PFT.Application.Contracts.Services;
using PFT.Entities.Domain;
using PFT.Entities.Domain.Enums;
using PFT.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PFT.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transactions> _repository;
        private readonly IMapper _mapper;

        public TransactionService(IRepository<Transactions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
        {
            var transactions = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(int id)
        {
            var transaction = await _repository.GetByIdAsync(id);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<TransactionDto> AddTransactionAsync(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transactions>(transactionDto);
            await _repository.AddAsync(transaction);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task UpdateTransactionAsync(int id, TransactionDto transactionDto)
        {
            if (!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException($"Transaction with ID {id} not found.");

            var transaction = _mapper.Map<Transactions>(transactionDto);
            transaction.TransactionId = id;
            await _repository.UpdateAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException($"Transaction with ID {id} not found.");

            await _repository.DeleteAsync(id);
        }

        public async Task<TransactionSummaryDto> GetTransactionSummaryAsync()
        {
            var transactions = await _repository.GetAllAsync();
            var income = transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var expenses = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            return new TransactionSummaryDto
            {
                TotalIncome = income,
                TotalExpenses = expenses,
                Savings = income - expenses
            };
        }
    }
}
