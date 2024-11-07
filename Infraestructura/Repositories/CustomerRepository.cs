using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public CustomerDTO CreateDto(Customer customer) => new()
    {
        Id = customer.Id,
        FullName = $"{customer.FirstName} {customer.LastName}"
    };

    public async Task<List<CustomerDTO>> List()
    {
        var entities = await _context.Customers.ToListAsync();
        var dtos = entities.Select(customer => CreateDto(customer));

        return dtos.OrderBy(c => c.Id).ToList();
    }

    public async Task<CustomerDTO> GetById(int Id)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(Id));

        if (entity is null)
            throw new Exception("Customer no encontrado");

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
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id.Equals(Id));

        if (entity is null)
            throw new Exception("Customer no encontrado");

        entity.FirstName = firstName;
        entity.LastName = lastName;

        await _context.SaveChangesAsync();

        return CreateDto(entity);
    }

    public async Task<CustomerDTO> DeleteCustomer(int Id)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(Id));

        if (entity is null)
            throw new Exception("Customer no encontrado");

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();

        return CreateDto(entity);
    }
}
