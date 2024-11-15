using Core.DTOs.Entity;

namespace Core.Interfaces.Services;

public interface ICustomerService
{
    Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO entity);
    Task<List<ResponseEntityDTO>> GetEntities(int CustomerId);

}
