using Security.Models;

namespace Security.IServices
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string email, string password);

        bool Authenticate(string plainPassword, LoginCustomer customer);
        
        string HashPassword(string plainPassword, byte[] salt);

        byte[] GenerateSalt();
    }
}