using Core.DTOs.Card;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<ResponseCardDto> Add(CreateCardDTO card);
    Task<DetailedCardDTO> GetById(int Id);
}
