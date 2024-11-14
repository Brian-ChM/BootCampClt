using Core.DTOs.Charges;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<ChargeDTO> AddCharges(int CardId, CreateChargeDTO charge);

    /// <summary>
    /// Verifica si el monto de la transacción es permitido. Retorna true si es permitido.
    /// </summary>
    /// <param name="cardId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<bool> VerifyChargeAmount(int cardId, decimal amount);
}
