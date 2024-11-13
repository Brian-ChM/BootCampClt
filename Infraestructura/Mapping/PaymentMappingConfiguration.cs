using Core.DTOs.Payments;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class PaymentMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<Payment, PaymentDTO>()
           //.Map(dest => dest.PaymentId, src => src.PaymentId);
    }
}
