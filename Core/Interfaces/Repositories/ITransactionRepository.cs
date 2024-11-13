using Core.DTOs.Transactions;

namespace Core.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task<List<TransactionDTO>> GetTransaction(int CardId);
}
