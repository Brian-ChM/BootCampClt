using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_customerRepository.List());
    }


    // Agregar
    [HttpPost("agregar")]
    public IActionResult Agregar([FromBody] Customer customer)
    {
        var newCustomer = _customerRepository.AddCustomer(customer);
        return Ok(newCustomer);
    }

    // Actualizar
    [HttpPut("actualizar/{Id}")]
    public IActionResult Update([FromRoute] int Id, [FromBody] Customer customer)
    {
        try
        {
            var updateCustomer = _customerRepository.UpdateCustomer(Id, customer);
            return Ok(updateCustomer);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Eliminar
    [HttpDelete("borrar/{Id}")]
    public IActionResult Delete([FromRoute] int Id)
    {
        try
        {
            _customerRepository.DeleteCustomer(Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    // Obtener por Id
    [HttpGet("list/{Id}")]
    public IActionResult GetById(int Id)
    {
        var customerById = _customerRepository.GetById(Id);
        return Ok(customerById);
    }
}
