using Security.Models;

namespace Security.IServices
{
    public interface ILoginCustomerService
    {
        LoginCustomer GetCustomerLogin(string email);
        
        LoginCustomer CreateLogin(LoginCustomer loginCustomer);

        void UpdateCustomerId(int id, string email);

        LoginCustomer UpdateLoginCustomer(LoginCustomer loginCustomer);
    }
}