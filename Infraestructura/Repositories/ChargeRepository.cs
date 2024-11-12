using Core.DTOs.Charges;
using Core.Interfaces.Repositories;
using Infraestructura.Context;

namespace Infraestructura.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly ApplicationDbContext _context;

    public ChargeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<ChargeDTO>> GetCharges(int Id)
    {
        throw new NotImplementedException();
    }
}
