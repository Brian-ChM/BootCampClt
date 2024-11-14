using Core.DTOs.Charges;
using Core.DTOs.Payments;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Context;
using Mapster;

namespace Infraestructura.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentDTO> AddPayments(int CardId, CreatePaymentDTO payment)
    {
        var Card = await _context.Cards.FindAsync(CardId);

        var AddPayment = payment.Adapt<Payment>();
        AddPayment.CardId = CardId;
        AddPayment.AvailableCredit = Card!.AvailableCredit + payment.Amount;

        Card.AvailableCredit += payment.Amount;
        _context.Payments.Add(AddPayment);
        await _context.SaveChangesAsync();

        return AddPayment.Adapt<PaymentDTO>();
    }

    public async Task<bool> VerifyPaymentAmount(int cardId, decimal amount)
    {
        var card = await _context.Cards.FindAsync(cardId);

        if (card is null)
            throw new Exception("No se encontró la tarjeta con el id provisto");

        return card.CreditLimit >= (card.AvailableCredit + amount);
    }
}
