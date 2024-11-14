using Core.DTOs.Card;
using Core.DTOs.Charges;
using Core.DTOs.Payments;
using Core.DTOs.Transactions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;

namespace Infraestructura.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IChargeRepository _chargeRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ITransactionRepository _transactionRepository;

    public CardService
        (
        ICardRepository cardRepository,
        IChargeRepository chargeRepository,
        IPaymentRepository paymentRepository,
        ITransactionRepository transactionRepository
        )
    {
        _cardRepository = cardRepository;
        _chargeRepository = chargeRepository;
        _paymentRepository = paymentRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<ResponseCardDto> CreateCard(CreateCardDTO createCard)
    {
        return await _cardRepository.AddCard(createCard);
    }

    public async Task<DetailedCardDTO> GetById(int Id)
    {
        return await _cardRepository.GetById(Id);
    }


    public async Task<ChargeDTO> CreateCharge(int CardId, CreateChargeDTO createCharge)
    {
        var IsTransactionAllowed = await _chargeRepository.VerifyChargeAmount(CardId, createCharge.Amount);

        if (!IsTransactionAllowed)
            throw new Exception("El monto supera el limite de crédito.");

        return await _chargeRepository.AddCharges(CardId, createCharge);
    }

    public async Task<PaymentDTO> CreatePayment(int CardId, CreatePaymentDTO createPayment)
    {
        var IsTransactionAllowed = await _paymentRepository.VerifyPaymentAmount(CardId, createPayment.Amount);

        if (!IsTransactionAllowed)
            throw new Exception("El monto supera el limite de crédito.");

        return await _paymentRepository.AddPayments(CardId, createPayment);
    }

    public async Task<List<TransactionDTO>> GetTransaction(int CardId, DateRequest date)
    {
        return await _transactionRepository.GetTransaction(CardId, date);
    }
}
