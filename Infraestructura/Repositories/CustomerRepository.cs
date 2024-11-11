using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using FluentValidation;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context, IValidator<CreateCustomerDTO> createValidator)
    {
        _context = context;
    }

    public async Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
    {
        var entities = await _context.Customers
            .Include(c => c.Accounts)
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(c => CustomerDto(c))
            .ToListAsync(cancellationToken);

        return entities;
    }

    public async Task<CustomerDTO> GetById(int Id)
    {
        var entity = await VerifyExists(Id);

        return CustomerDto(entity);
    }

    public async Task<CustomerDTO> AddCustomer(CreateCustomerDTO CreateCustomer)
    {
        var entity = new Customer
        {
            FirstName = CreateCustomer.FirstName,
            LastName = CreateCustomer.LastName,
            Email = CreateCustomer.Email,
            Phone = CreateCustomer.Phone,
            FechaDeNac = CreateCustomer.FechaDeNac,
        };

        _context.Customers.Add(entity);
        await _context.SaveChangesAsync();

        return CustomerDto(entity);
    }

    public async Task<CustomerDTO> UpdateCustomer(UpdateCustomerDTO UpdateCustomer)
    {
        var entity = await VerifyExists(UpdateCustomer.Id);

        entity.FirstName = UpdateCustomer.FirstName;
        entity.LastName = UpdateCustomer.LastName;
        entity.Email = UpdateCustomer.Email;
        entity.Phone = UpdateCustomer.Phone;
        entity.FechaDeNac = UpdateCustomer.FechaDeNac;

        await _context.SaveChangesAsync();
        return CustomerDto(entity);
    }

    public async Task<CustomerDTO> DeleteCustomer(int Id)
    {
        var entity = await VerifyExists(Id);

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();

        return CustomerDto(entity);
    }

    private static CustomerDTO CustomerDto(Customer customer) => new()
    {
        Id = customer.Id,
        FullName = $"{customer.FirstName} {customer.LastName}",
        Phone = customer.Phone,
        Email = customer.Email,
        FechaDeNac = customer.FechaDeNac.ToShortDateString(),
        accounts = customer.Accounts.Select(x => new DetailedCustomerDTO
        {
            Id = x.Id,
            Balance = x.Balance,
            Number = x.Number,
            OpeningDate = x.OpeningDate.ToShortDateString()
        }).ToList()
    };

    private async Task<Customer> VerifyExists(int id)
    {
        return await _context.Customers.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Id == id) ??
            throw new Exception("No se encontró con el id solicitado");
    }

}
