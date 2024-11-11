using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infraestructura.Context;
using Mapster;
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
            .ToListAsync();

        return entity.Adapt<List<DetailedAccountDTO>>();
    }

    public async Task<DetailedAccountDTO> GetById(int Id)
    {
        var entity = await VerifyExists(Id);
        return entity.Adapt<DetailedAccountDTO>();
    }

    private async Task<Account> VerifyExists(int Id)
    {
        return await _context.Accounts
            .Include(account => account.Customer)
            .FirstOrDefaultAsync(a => a.Id == Id) ??
            throw new Exception("No se encontró con el id solicitado");
    }
}
