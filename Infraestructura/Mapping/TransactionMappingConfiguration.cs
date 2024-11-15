using Core.DTOs.Transactions;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class TransactionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Charge, TransactionDTO>()
            .Map(dest => dest.Type, src => "Charge");

        config.NewConfig<Payment, TransactionDTO>()
            .Map(dest => dest.Type, src => "Payment")
            .Map(dest => dest.Description, src => "Pago recibido");
    }
}
