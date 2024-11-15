using Core.DTOs.Account;
using Core.DTOs.Card;
using Core.DTOs.Customer;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class CustomerMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerDTO>()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.FechaDeNac, src => src.FechaDeNac.ToShortDateString())
            .Map(dest => dest.Accounts, src => src.Accounts.Select(x => x.Adapt<CustomerAccountDetailedDTO>()));

        config.NewConfig<Account, CustomerAccountDetailedDTO>()
            .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString());

        config.NewConfig<Customer, CardCustomerDTO>()
            .Map(dest => dest.CardNumber, src => src.Cards
            .Select(x => $"XXXX-XXXX-XXXX-{x.CardNumber.Substring((x.CardNumber.Length - 4), 4)}"));
    }
}