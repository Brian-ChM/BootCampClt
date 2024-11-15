using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class EntityRepository : IEntityRepository
{
    private readonly ApplicationDbContext _context;

    public EntityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResponseEntityDTO>> GetEntities(int CustomerId)
    {
        var entitiesWithProducts = await _context.CustomerEntities
            .Include(e => e.Entity)
                .ThenInclude(e => e.Products)
            .Where(e => e.CustomerId == CustomerId) 
            .Select(e => e.Entity)
            .ToListAsync();

        return entitiesWithProducts.Select(e => new ResponseEntityDTO
        {
            Entidad = e.EntityName,
            Products = e.Products.Select(p => new ResponseProductDTO
            {
                Product = p.ProductName,
                StartDate = p.StartDate.ToShortDateString()
            }).ToList()
        }).ToList();
    }
}
