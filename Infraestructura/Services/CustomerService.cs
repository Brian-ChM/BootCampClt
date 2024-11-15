using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Infraestructura.Services;

public class CustomerService : ICustomerService
{
    private readonly IEntityRepository _entityRepository;

    public CustomerService(IEntityRepository entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public async Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO entity)
    {
        return await _entityRepository.CreateEntity(entity);
    }

    public async Task<List<ResponseEntityDTO>> GetEntities(int CustomerId)
    {
        return await _entityRepository.GetEntities(CustomerId);
    }
}
