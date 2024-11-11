using Core.Interfaces.Repositories;
using Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AccountController: BaseApiController
{
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        return Ok(await _accountRepository.GetAll(request));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetAll([FromRoute] int Id)
    {
        return Ok(await _accountRepository.GetById(Id));
    }
}
