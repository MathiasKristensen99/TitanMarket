using Security.Models;

namespace Security.IRepositories
{
    public interface ILoginCustomerRepository
    {
        LoginCustomer FindCustomer(string email);

        LoginCustomer CreateLogin(LoginCustomer loginCustomer);
        
        void UpdateCustomerId(int newId, string email);
        
        LoginCustomer UpdateLoginCustomer(LoginCustomer loginCustomer);
    }
}