using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private static List<Customer> _customers = [
        new() { Id = 1, Name = "Brian" },
        new() { Id = 2, Name = "Fernando" },
        ];

    public List<Customer> List()
    {
        return _customers;
    }

    public Customer GetById(int Id)
    {
        var customer = _customers.SingleOrDefault(c => c.Id.Equals(Id));
        if (customer is null)
            customer = new Customer();

        return customer;
    }

    public Customer AddCustomer(Customer customer)
    {
        _customers.Add(customer);
        return customer;
    }

    public Customer UpdateCustomer(int Id, Customer customer)
    {
        var updateCustomer = _customers.SingleOrDefault(c => c.Id.Equals(Id));

        if (updateCustomer is null)
            throw new Exception("El customer no pudo ser actualizado.");

        updateCustomer.Id = customer.Id;
        updateCustomer.Name = customer.Name;

        return updateCustomer;
    }

    public void DeleteCustomer(int Id)
    {
        var deleteCustomer = _customers.SingleOrDefault(c => c.Id.Equals(Id));
        if (deleteCustomer is null)
            throw new Exception("El customer no pudo ser eliminado.");

        _customers.Remove(deleteCustomer);
    }
}
