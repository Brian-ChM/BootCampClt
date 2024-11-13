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
        var Card = await _context.Cards.FindAsync(CardId) ??
            throw new Exception("El Id de la tarjeta no es valido.");

        var NewAvailableCredit = Card.CreditLimit >= (Card.AvailableCredit + payment.Amount)
            ? Card.AvailableCredit + payment.Amount
            : throw new Exception($"El monto supera el limite de crédito. Le queda por pagar {Card.CreditLimit - Card.AvailableCredit}");

        var AddPayment = payment.Adapt<Payment>();

        Card.AvailableCredit = NewAvailableCredit;

        _context.Payments.Add(AddPayment);
        await _context.SaveChangesAsync();

        return AddPayment.Adapt<PaymentDTO>();

    }
}
