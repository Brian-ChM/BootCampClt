using Core.DTOs.Payments;

namespace Core.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<PaymentDTO> AddPayments(int CardId, CreatePaymentDTO payment);

    /// <summary>
    /// Verifica si el monto de la transacción es permitido. Retorna true si es permitido.
    /// </summary>
    /// <param name="cardId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<bool> VerifyPaymentAmount(int cardId, decimal amount);
}
