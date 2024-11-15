using Core.DTOs.Account;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class AccountMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Account, DetailedAccountDTO>()
            .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString())
            .Map(dest => dest.Customer, src => src.Customer.Adapt<AccountCustomerDetailedDTO>());

        config.NewConfig<Customer, AccountCustomerDetailedDTO>()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.FechaDeNac, src => src.FechaDeNac.ToShortDateString());
    }
}