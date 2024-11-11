using Core.DTOs;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<List<DetailedAccountDTO>> GetAll(PaginationRequest request);
    Task<DetailedAccountDTO> GetById(int Id);
}
