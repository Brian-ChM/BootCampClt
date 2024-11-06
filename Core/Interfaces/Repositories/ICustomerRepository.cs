using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    List<Customer> List();
    Customer GetById(int Id);
    Customer AddCustomer(Customer customer);
    Customer UpdateCustomer(int Id, Customer customer);
    void DeleteCustomer(int Id);
}
