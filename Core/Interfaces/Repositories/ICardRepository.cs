using Core.DTOs.Card;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<CardDTO> Add(CreateCardDTO card);
    Task<DetailedCardDTO> GetById(int Id);
}
