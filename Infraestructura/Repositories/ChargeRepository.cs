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
        var Card = await _context.Cards.FindAsync(CardId);

        var AddCharge = charge.Adapt<Charge>();
        AddCharge.CardId = CardId;
        AddCharge.AvailableCredit = Card!.AvailableCredit - charge.Amount;

        Card.AvailableCredit -= charge.Amount;
        _context.Charges.Add(AddCharge);
        await _context.SaveChangesAsync();

        return AddCharge.Adapt<ChargeDTO>();
    }

    public async Task<bool> VerifyChargeAmount(int cardId, decimal amount)
    {
        var card = await _context.Cards.FindAsync(cardId);

        if (card is null)
            throw new Exception("No se encontró la tarjeta con el id provisto");

        return card.AvailableCredit >= amount;
    }
}
