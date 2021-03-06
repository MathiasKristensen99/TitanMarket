using System.Collections.Generic;
using TitanMarket.Core.Models;

namespace TitanMarket.Core.IServices
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);

        Customer GetCustomerByEmail(string email);

        List<Customer> GetAllCustomers();

        bool CheckIfCustomerExists(string email);

        Customer CreateCustomer(Customer customer);

        Customer DeleteCustomer(int id);

        Customer UpdateCustomer(Customer customer);
    }
}