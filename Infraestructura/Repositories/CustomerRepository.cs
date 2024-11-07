using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerDTO>> List(PaginationRequest request)
    {
        var entities = await _context.Customers.ToListAsync();
        var dtos = entities
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(customer => CreateDto(customer));

        return dtos.OrderBy(c => c.Id).ToList();
    }

    public async Task<CustomerDTO> GetById(int Id)
    {
        var entity = await VerifyExists(Id);

        return CreateDto(entity);
    }

    public async Task<CustomerDTO> AddCustomer(string firstName, string lastName)
    {
        var entity = new Customer
        {
            FirstName = firstName,
            LastName = lastName
        };

        _context.Customers.Add(entity);
        await _context.SaveChangesAsync();

        return CreateDto(entity);
    }

    public async Task<CustomerDTO> UpdateCustomer(int Id, string firstName, string lastName)
    {
        var entity = await VerifyExists(Id);

        entity.FirstName = firstName;
        entity.LastName = lastName;

        await _context.SaveChangesAsync();

        return CreateDto(entity);
    }

    public async Task<CustomerDTO> DeleteCustomer(int Id)
    {
        var entity = await VerifyExists(Id);

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();

        return CreateDto(entity);
    }

    private CustomerDTO CreateDto(Customer customer) => new()
    {
        Id = customer.Id,
        FullName = $"{customer.FirstName} {customer.LastName}",
        Phone = customer.Phone,
        Email = customer.Email,
        FechaDeNac = customer.FechaDeNac.ToShortTimeString(),
    };

    private async Task<Customer> VerifyExists(int id)
    {
        return await _context.Customers.FindAsync(id) ??
            throw new Exception("No se encontró con el id solicitado");
    }

}
