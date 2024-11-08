using Core.DTOs;
using Core.Entities;
using Core.Request;


namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken);
    Task<CustomerDTO> GetById(int Id);
    Task<CustomerDTO> AddCustomer(CreateCustomerDTO CreateCustomer);
    Task<CustomerDTO> UpdateCustomer(UpdateCustomerDTO UpdateCustomer);
    Task<CustomerDTO> DeleteCustomer(int Id);
}
