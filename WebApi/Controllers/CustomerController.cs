using Core.DTOs.Customer;
using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<CreateCustomerDTO> _validateCreate;
    private readonly IValidator<UpdateCustomerDTO> _validateUpdate;
    private readonly ICustomerService _customerService;

    public CustomerController
        (
        ICustomerRepository customerRepository,
        IValidator<CreateCustomerDTO> validateCreate,
        IValidator<UpdateCustomerDTO> validateUpdate,
        ICustomerService customerService
        )
    {
        _customerRepository = customerRepository;
        _validateCreate = validateCreate;
        _validateUpdate = validateUpdate;
        _customerService = customerService;
    }

    // Obtener todos
    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _customerRepository.List(request, cancellationToken));
    }

    // Obtener por Id
    [HttpGet("list/{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        var customerById = await _customerRepository.GetById(Id);
        return Ok(customerById);
    }

    [HttpPost("agregar")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDTO CreateCustomer)
    {
        var results = await _validateCreate.ValidateAsync(CreateCustomer);

        if (!results.IsValid)
            return BadRequest(results.Errors);

        return Ok(await _customerRepository.AddCustomer(CreateCustomer));
    }

    // Actualizar
    [HttpPut("actualizar")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO UpdateCustomer)
    {
        var results = await _validateUpdate.ValidateAsync(UpdateCustomer);

        if (!results.IsValid)
            return BadRequest(results.Errors);

        var updateCustomer = await _customerRepository.UpdateCustomer(UpdateCustomer);
        return Ok(updateCustomer);
    }

    // Eliminar
    [HttpDelete("borrar/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] int Id)
    {
        return Ok(await _customerRepository.DeleteCustomer(Id));
    }

    // Obtener cards por el Id del customer
    [HttpGet("{Id}/cards")]
    public async Task<IActionResult> GetCardsByCustomer([FromRoute] int Id)
    {
        return Ok(await _customerRepository.GetCardsByCustomer(Id));
    }


    // Agregar Entidades por Customer ID
    [HttpPost("{CustomerId}/entities")]
    public async Task<IActionResult> AddEntity([FromBody] CreateEntityDTO entity)
    {
        return Ok(await _customerService.CreateEntity(entity));
    }

    // Obtener Entidades por Customer ID
    [HttpGet("{CustomerId}/entities")]
    public async Task<IActionResult> GetEntity([FromRoute] int CustomerId)
    {
        return Ok(await _customerService.GetEntities(CustomerId));
    }
}
