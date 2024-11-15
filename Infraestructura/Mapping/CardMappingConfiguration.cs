using Core.DTOs.Card;
using Core.DTOs.Charges;
using Core.DTOs.Transactions;
using Core.Entities;
using Mapster;
using System.Linq;

namespace Infraestructura.Mapping;

public class CardMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCardDTO, Card>()
            .Map(dest => dest.CardNumber, src => GetCardNumber())
            .Map(dest => dest.AvailableCredit, src => new Random().Next(0, (int)src.CreditLimit))
            .Map(dest => dest.Status, src => "active");

        config.NewConfig<Card, DetailedCardDTO>()
            .Map(dest => dest.CardNumber, src => $"XXXX-XXXX-XXXX-{src.CardNumber.Substring(src.CardNumber.Length - 4, 4)}");

        config.NewConfig<Customer, CardCustomerDTO>()
            .Map(dest => dest.CardId, src => src.Cards.Select(x => x.CardId))
            .Map(dest => dest.AvailableCredit, src => src.Cards.Select(x => x.AvailableCredit))
            .Map(dest => dest.CardNumber, src => src.Cards.Select(x => x.CardNumber))
            .Map(dest => dest.CreditLimit, src => src.Cards.Select(x => x.CreditLimit))
            .Map(dest => dest.ExpirationDate, src => src.Cards.Select(x => x.ExpirationDate));

        config.NewConfig<Card, ResponseCardDto>()
            .Map(dest => dest.CardNumber, src => $"XXXX-XXXX-XXXX-{src.CardNumber.Substring(src.CardNumber.Length - 4, 4)}");
    }

    public static string GetCardNumber()
    {
        var random = new Random();
        List<string> CardNumber = [];
        for (int i = 0; i < 4; i++)
        {
            CardNumber.Add(random.Next(1000, 10000).ToString());
        }
        return String.Join('-', CardNumber);
    }
}
