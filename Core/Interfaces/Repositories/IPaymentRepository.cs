using Core.DTOs.Payments;

namespace Core.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<List<PaymentDTO>> GetPayments(int Id);
}
