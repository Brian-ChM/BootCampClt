using Core.DTOs.Payments;

namespace Core.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<PaymentDTO> AddPayments(int CardId, CreatePaymentDTO payment);
}
