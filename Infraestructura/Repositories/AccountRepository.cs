using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infraestructura.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DetailedAccountDTO>> GetAll(PaginationRequest request)
    {
        var entity = await _context.Accounts
            .Include(a => a.Customer)
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(a => AccountDto(a))
            .ToListAsync();

        return entity;
    }

    public async Task<DetailedAccountDTO> GetById(int Id)
    {
        var entity = await VerifyExists(Id);
        return AccountDto(entity);
    }

    private static DetailedAccountDTO AccountDto(Account account) => new DetailedAccountDTO
    {
        Id = account.Id,
        Number = account.Number,
        Balance = account.Balance,
        OpeningDate = account.OpeningDate.ToShortDateString(),
        Customer = new CustomerDTO()
        {
            Id = account.Customer.Id,
            FullName = $"{account.Customer.FirstName} {account.Customer.LastName}",
            Email = account.Customer.Email,
            Phone = account.Customer.Phone,
            FechaDeNac = account.Customer.FechaDeNac.ToShortDateString()
        }
    };

    private async Task<Account> VerifyExists(int Id)
    {
        return await _context.Accounts
            .Include(account => account.Customer)
            .FirstOrDefaultAsync(a => a.Id == Id) ??
            throw new Exception("No se encontró con el id solicitado");
    }
}
