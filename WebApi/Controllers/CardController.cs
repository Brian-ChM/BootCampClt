using Core.DTOs.Card;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CardController: BaseApiController
{
    private readonly ICardRepository _cardRepository;

    public CardController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCardDTO card)
    {
        return Ok(await _cardRepository.Add(card));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        return Ok(await _cardRepository.GetById(Id));
    }
}
