using Core.DTOs.Card;
using Core.DTOs.Charges;
using Core.DTOs.Payments;
using Core.Interfaces.Services;
using Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CardController : BaseApiController
{
    private readonly ICardService _service;

    public CardController(ICardService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCardDTO card)
    {
        return Ok(await _service.CreateCard(card));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        return Ok(await _service.GetById(Id));
    }

    [HttpPost("{CardId}/charges")]
    public async Task<IActionResult> AddCharge([FromRoute] int CardId, [FromBody] CreateChargeDTO charge)
    {
        return Ok(await _service.CreateCharge(CardId, charge));
    }

    [HttpPost("{CardId}/payment")]
    public async Task<IActionResult> AddPayment([FromRoute] int CardId, [FromBody] CreatePaymentDTO charge)
    {
        return Ok(await _service.CreatePayment(CardId, charge));
    }

    [HttpGet("{CardId}/transactions")]
    public async Task<IActionResult> GetTransactions([FromRoute] int CardId, [FromQuery] DateRequest Date)
    {
        return Ok(await _service.GetTransaction(CardId, Date));
    }
}