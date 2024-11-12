using Core.DTOs.Card;
using Core.DTOs.Customer;
using Core.Request;


namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CardCustomerDTO>> GetCardsByCustomer(int Id);

    Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken);
    Task<CustomerDTO> GetById(int Id);
    Task<CustomerDTO> AddCustomer(CreateCustomerDTO CreateCustomer);
    Task<CustomerDTO> UpdateCustomer(UpdateCustomerDTO UpdateCustomer);
    Task<CustomerDTO> DeleteCustomer(int Id);
}
