using Core.DTOs;
using Core.Entities;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List(PaginationRequest request);
    Task<CustomerDTO> GetById(int Id);
    Task<CustomerDTO> AddCustomer(string firstName, string lastName);
    Task<CustomerDTO> UpdateCustomer(int Id, string firstName, string lastName);
    Task<CustomerDTO> DeleteCustomer(int Id);
}
