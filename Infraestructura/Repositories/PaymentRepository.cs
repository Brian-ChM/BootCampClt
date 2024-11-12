using Core.DTOs.Payments;
using Core.Interfaces.Repositories;
using Infraestructura.Context;

namespace Infraestructura.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<PaymentDTO>> GetPayments(int Id)
    {
        throw new NotImplementedException();
    }
}
