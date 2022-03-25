using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TitanMarket.WebApi.Dtos
{
    public class CustomersDto
    {
        public List<CustomerDto> List { get; set; }
    }
}