using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TitanMarket.Core.IServices;
using TitanMarket.Core.Models;
using Security.IServices;
using Security.Models;
using TitanMarket.WebApi.Dtos;

namespace TitanMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly ILoginCustomerService _loginCustomerService;
        private readonly ICustomerService _customerService;

        public AuthController(ISecurityService securityService, ILoginCustomerService customerService, ICustomerService service)
        {
            _securityService = securityService;
            _loginCustomerService = customerService;
            _customerService = service;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login(LoginDto dto)
        {
            try
            {
                var token = _securityService.GenerateJwtToken(dto.Email, dto.Password);
                return new TokenDto
                {
                    Jwt = token.Jwt,
                    Message = token.Message
                };
            }
            catch (AuthenticationException ae)
            {
                return Unauthorized(ae.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<LoginCustomer> CreateLoginCustomer([FromBody] CreateLoginCustomerDto dto)
        {
            var salt = _securityService.GenerateSalt();
            
            var customer = new Customer
            {
                Id = dto.Id,
                Email = dto.Email
            };

            if (!_customerService.CheckIfCustomerExists(customer.Email))
            {
                _customerService.CreateCustomer(customer);
                
                var newCustomer = _customerService.GetCustomerByEmail(customer.Email);
            
                var loginCustomerFromDto = new LoginCustomer
                {
                    Id = dto.Id,
                    Email = dto.Email,
                    Salt = salt,
                    HashedPassword = _securityService.HashPassword(dto.PlainTextPassword, salt),
                    CustomerId = newCustomer.Id
                };
                try
                {
                    var newLoginCustomer = _loginCustomerService.CreateLogin(loginCustomerFromDto);
                    return Created($"https://localhost:5001/api/auth/{newLoginCustomer.Id}", newLoginCustomer);
                }
                catch (ArgumentException ae)
                {
                    return BadRequest(ae.Message);
                }
            }

            return BadRequest("User with the given email already exists");
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<UpdateLoginCustomerDto> UpdateCustomer(int id, UpdateLoginCustomerDto dto)
        {
            string currentCustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int customerId = Int32.Parse(currentCustomerId);
            Customer customer = _customerService.GetCustomerById(customerId);
            
            if (id != dto.Id)
            {
                return BadRequest("It is not a match");
            }

            var loginCustomer = _loginCustomerService.GetCustomerLogin(customer.Email);

            if (loginCustomer != null)
            {
                loginCustomer.Email = dto.Email;
            }

            if (customer != null)
            {
                customer.Email = dto.Email;
            }

            try
            {
                _loginCustomerService.UpdateLoginCustomer(loginCustomer);
                _customerService.UpdateCustomer(customer);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException(ae.Message);
            }

            return Ok(dto);
        }

        [Authorize]
        [HttpPut("password/{id:int}")]
        public ActionResult<UpdatePasswordDto> UpdatePassword(int id, UpdatePasswordDto dto)
        {
            string currentCustomerEmail = User.FindFirstValue(ClaimTypes.Email);
            LoginCustomer loginCustomer = _loginCustomerService.GetCustomerLogin(currentCustomerEmail);

            if (id != dto.Id)
            {
                return BadRequest("It is not a match");
            }

            var salt = _securityService.GenerateSalt();

            if (loginCustomer != null)
            {
                loginCustomer.Salt = salt;
                loginCustomer.HashedPassword = _securityService.HashPassword(dto.PlainTextPassword, salt);
            }

            try
            {
                _loginCustomerService.UpdateLoginCustomer(loginCustomer);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException(ae.Message);
            }

            return Ok(dto);
        }
    }
}