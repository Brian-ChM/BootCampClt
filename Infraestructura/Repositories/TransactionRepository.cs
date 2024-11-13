using Core.DTOs.Transactions;
using Core.Interfaces.Repositories;
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

    public async Task<List<TransactionDTO>> GetTransaction(int CardId)
    {

        var transactions = await _context.Cards
            .Include(c => c.Payments)
            .Include(c => c.Charges)
            .FirstOrDefaultAsync(c => c.CardId.Equals(CardId))
            ?? throw new Exception("No se encuentra con el CardId solicitado.");

        var payments = transactions.Payments.Select(p => new TransactionDTO
        {
            Type = "Payment",
            Amount = p.Amount,
            Date = p.Date,
            Description = "Pago recibido"
        }).ToList();

        var charges = transactions.Charges.Select(c => new TransactionDTO
        {
            Type = "Charge",
            Amount = c.Amount,
            Date = c.Date,
            Description= c.Description,
        }).ToList();

        return payments.Concat(charges)
            .OrderByDescending(res => res.Date).ToList();
    }
}
