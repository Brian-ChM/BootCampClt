using Core.DTOs.Card;
using Core.DTOs.Charges;
using Core.DTOs.Payments;
using Core.DTOs.Transactions;
using Core.Request;

namespace Core.Interfaces.Services;

public interface ICardService
{
    Task<ResponseCardDto> CreateCard(CreateCardDTO createCard);
    Task<ChargeDTO> CreateCharge(int CardId, CreateChargeDTO createCharge);
    Task<PaymentDTO> CreatePayment(int CardId, CreatePaymentDTO createPayment);
    Task<DetailedCardDTO> GetById(int Id);
    Task<List<TransactionDTO>> GetTransaction(int CardId, DateRequest date);
}
