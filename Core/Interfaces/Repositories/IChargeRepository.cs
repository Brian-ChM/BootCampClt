using Core.DTOs.Charges;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<ChargeDTO> AddCharges(int CardId, CreateChargeDTO charge);
}
