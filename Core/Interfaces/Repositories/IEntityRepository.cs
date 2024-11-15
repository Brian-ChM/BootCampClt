using Core.DTOs.Entity;

namespace Core.Interfaces.Repositories;

public interface IEntityRepository
{
    Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO entity);
    Task<List<ResponseEntityDTO>> GetEntities(int CustomerId);
}
