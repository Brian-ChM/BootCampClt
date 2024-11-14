using Core.DTOs.Card;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<ResponseCardDto> AddCard(CreateCardDTO card);
    Task<DetailedCardDTO> GetById(int Id);
}
