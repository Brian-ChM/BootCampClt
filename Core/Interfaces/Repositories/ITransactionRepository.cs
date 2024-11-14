using Core.DTOs.Transactions;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task<List<TransactionDTO>> GetTransaction(int CardId, DateRequest date);
}
