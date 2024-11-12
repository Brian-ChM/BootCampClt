using Core.DTOs.Charges;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<List<ChargeDTO>> GetCharges(int Id);
}
