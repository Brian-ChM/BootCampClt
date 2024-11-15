using Core.DTOs.Transactions;
using Core.Interfaces.Repositories;
using Core.Request;
using Infraestructura.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionDTO>> GetTransaction(int CardId, DateRequest date)
    {
        var start = date.Start.ToDateTime(TimeOnly.MinValue);
        var end = date.End.ToDateTime(TimeOnly.MaxValue);

        var transactions = await _context.Cards
            .Include(c => c.Payments)
            .Include(c => c.Charges)
            .FirstOrDefaultAsync(c => c.CardId.Equals(CardId))
            ?? throw new Exception("No se encuentra con el CardId solicitado.");

        var payments = transactions.Payments.Select(p => p.Adapt<TransactionDTO>()).ToList();
        var charges = transactions.Charges.Select(c => c.Adapt<TransactionDTO>()).ToList();

        return payments.Concat(charges)
            .OrderByDescending(res => res.Date)
            .Where(x => x.Date >= start && x.Date <= end)
            .ToList();
    }
}
