using Core.DTOs.Payments;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class PaymentMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePaymentDTO, Payment>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod)
            .Map(dest => dest.Date, src => src.Date);
    }
}

/*

        var AddPayment = new Payment
        {
            CardId = CardId,
            Amount = payment.Amount,
            AvailableCredit = NewAvailableCredit,
            PaymentMethod = payment.PaymentMethod,
            Date = payment.Date,
        };

*/