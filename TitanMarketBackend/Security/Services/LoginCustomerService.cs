using Security.IRepositories;
using Security.IServices;
using Security.Models;

namespace Security.Services
{
    public class LoginCustomerService : ILoginCustomerService
    {
        private readonly ILoginCustomerRepository _customerRepository;
        
        public LoginCustomerService(ILoginCustomerRepository loginCustomerRepository)
        {
            _customerRepository = loginCustomerRepository;
        }
        
        public LoginCustomer GetCustomerLogin(string email)
        {
            return _customerRepository.FindCustomer(email);
        }

        public LoginCustomer CreateLogin(LoginCustomer loginCustomer)
        {
            return _customerRepository.CreateLogin(loginCustomer);
        }

        public void UpdateCustomerId(int newId, string email)
        {
            _customerRepository.UpdateCustomerId(newId, email);
        }

        public LoginCustomer UpdateLoginCustomer(LoginCustomer loginCustomer)
        {
            return _customerRepository.UpdateLoginCustomer(loginCustomer);
        }
    }
}