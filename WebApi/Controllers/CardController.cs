using Core.DTOs.Card;
using Core.DTOs.Charges;
using Core.DTOs.Payments;
using Core.Interfaces.Repositories;
using Infraestructura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CardController : BaseApiController
{
    private readonly ICardRepository _cardRepository;
    private readonly IChargeRepository _chargeRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ITransactionRepository _transactionRepository;

    public CardController
        (
        ICardRepository cardRepository,
        IChargeRepository chargeRepository,
        IPaymentRepository paymentRepository,
        ITransactionRepository transactionRepository
        )
    {
        _cardRepository = cardRepository;
        _chargeRepository = chargeRepository;
        _paymentRepository = paymentRepository;
        _transactionRepository = transactionRepository;
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

    [HttpPost("{CardId}/charges")]
    public async Task<IActionResult> AddCharge([FromRoute] int CardId, [FromBody] CreateChargeDTO charge)
    {
        return Ok(await _chargeRepository.AddCharges(CardId, charge));
    }

    [HttpPost("{CardId}/payment")]
    public async Task<IActionResult> AddPayment([FromRoute] int CardId, [FromBody] CreatePaymentDTO charge)
    {
        return Ok(await _paymentRepository.AddPayments(CardId, charge));
    }

    [HttpGet("{CardId}/transactions")]
    public async Task<IActionResult> GetTransactions([FromRoute] int CardId)
    {
        return Ok(await _transactionRepository.GetTransaction(CardId));
    }
}
