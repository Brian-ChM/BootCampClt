using Core.DTOs;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class AccountMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Account, DetailedAccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString())
            .Map(dest => dest.Customer, src => src.Customer.Adapt<AccountCustomerDetailedDTO>());

        config.NewConfig<Customer, AccountCustomerDetailedDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.FechaDeNac, src => src.FechaDeNac.ToShortDateString());
    }
}