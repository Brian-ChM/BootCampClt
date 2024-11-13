using Core.DTOs.Charges;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Context;
using Mapster;

namespace Infraestructura.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly ApplicationDbContext _context;

    public ChargeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ChargeDTO> AddCharges(int CardId, CreateChargeDTO charge)
    {
        var Card = await _context.Cards.FindAsync(CardId) ??
            throw new Exception("El Id de la tarjeta no es valido.");

        var NewAvailableCredit = Card.AvailableCredit >= charge.Amount
            ? Card.AvailableCredit - charge.Amount
            : throw new Exception("El monto supera el limite de crédito.");

        var AddCard = new Charge
        {
            CardId = CardId,
            Amount = charge.Amount,
            AvailableCredit = NewAvailableCredit,
            Description = charge.Description,
            Date = charge.Date,
        };

        Card.AvailableCredit = NewAvailableCredit;

        _context.Charges.Add(AddCard);
        await _context.SaveChangesAsync();

        return AddCard.Adapt<ChargeDTO>();
    }
}
