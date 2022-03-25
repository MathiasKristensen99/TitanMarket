using System;
using TitanMarket.Core.Models;

namespace TitanMarket.WebApi.Dtos
{
    public class CreateLoginCustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PlainTextPassword { get; set; }
        public int CustomerId { get; set; }
    }
}