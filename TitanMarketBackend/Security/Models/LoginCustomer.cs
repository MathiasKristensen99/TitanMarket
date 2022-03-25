using TitanMarket.Core.Models;

namespace Security.Models
{
    public class LoginCustomer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}