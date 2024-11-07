using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    // Obtener todos
    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        return Ok(await _customerRepository.List());
    }

    // Obtener por Id
    [HttpGet("list/{Id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        var customerById = await _customerRepository.GetById(Id);
        return Ok(customerById);
    }

    [HttpPost("agregar")]
    public async Task<IActionResult> Add([FromBody] Customer customer)
    {
        return Ok(await _customerRepository.AddCustomer(customer.FirstName, customer.LastName));
    }

    // Actualizar
    [HttpPut("actualizar")]
    public async Task<IActionResult> Update([FromBody] Customer customer)
    {
        try
        {
            var updateCustomer = await _customerRepository
                .UpdateCustomer(customer.Id, customer.FirstName, customer.LastName);

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
