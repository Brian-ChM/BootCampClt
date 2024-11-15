using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

internal class EntityMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entity, ResponseEntityDTO>()
            .Map(dest => dest.Entidad, src => src.EntityName)
            .Map(dest => dest.Products, src => src.Products.Select(x => x.Adapt<ResponseProductDTO>()));

        config.NewConfig<Product, ResponseProductDTO>()
            .Map(dest => dest.Product, src => src.ProductName);
    }
}
