using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<CreateCustomerDTO> _validateCreate;

    public CustomerController(ICustomerRepository customerRepository, IValidator<CreateCustomerDTO> validateCreate)
    {
        _customerRepository = customerRepository;
        _validateCreate = validateCreate;
    }

    // Obtener todos
    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _customerRepository.List(request, cancellationToken));
    }

    // Obtener por Id
    [HttpGet("list/{Id}")]
    public async Task<IActionResult> GetById(int Id)
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
        try
        {
            var updateCustomer = await _customerRepository.UpdateCustomer(UpdateCustomer);
            return Ok(updateCustomer);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Eliminar
    [HttpDelete("borrar/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] int Id)
    {
        try
        {
            return Ok(await _customerRepository.DeleteCustomer(Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
