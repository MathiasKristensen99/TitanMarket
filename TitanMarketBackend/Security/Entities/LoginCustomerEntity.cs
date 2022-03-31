using System;
using Microsoft.EntityFrameworkCore.Metadata;
using TitanMarket.Core.Models;

namespace Security.Entities
{
    public class LoginCustomerEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public int CustomerId { get; set; }
    }
}