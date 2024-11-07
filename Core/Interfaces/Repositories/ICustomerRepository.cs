using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List();
    Task<CustomerDTO> GetById(int Id);
    Task<CustomerDTO> AddCustomer(string firstName, string lastName);
    Task<CustomerDTO> UpdateCustomer(int Id, string firstName, string lastName);
    Task<CustomerDTO> DeleteCustomer(int Id);
}
