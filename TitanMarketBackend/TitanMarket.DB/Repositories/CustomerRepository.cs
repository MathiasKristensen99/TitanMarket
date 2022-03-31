using System;
using System.Collections.Generic;
using System.Linq;
using TitanMarket.Core.Models;
using TitanMarket.DB.Entities;
using TitanMarket.Domain.IRepositories;


namespace TitanMarket.DB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TitanMarketDbContext _ctx;
        
        public CustomerRepository(TitanMarketDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public Customer GetCustomerById(int id)
        {
            return _ctx.Customers
                .Select(entity => new Customer
                {
                    Id = entity.Id,
                    Email = entity.Email
                }).FirstOrDefault(customer => customer.Id == id);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _ctx.Customers
                .Select(entity => new Customer
                {
                    Id = entity.Id,
                    Email = entity.Email
                }).FirstOrDefault(customer => customer.Email == email);
        }

        public List<Customer> GetAllCustomers()
        {
            return null;
        }

        public bool CheckIfCustomerExists(string email)
        {
            var entity = _ctx.Customers.Select(customerEntity => new Customer
            {
                Email = customerEntity.Email,
                Id = customerEntity.Id
            }).FirstOrDefault(customer => customer.Email == email);

            if (entity == null)
            {
                return false;
            }

            return true;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var entity = _ctx.Customers.Add(new CustomerEntity
            {
                Id = customer.Id,
                Email = customer.Email
            }).Entity;

            _ctx.SaveChanges();

            return new Customer
            {
                Id = entity.Id,
                Email = entity.Email
            };
        }

        public Customer DeleteCustomer(int id)
        {
            var entity = _ctx.Customers.Remove(new CustomerEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Customer
            {
                Id = entity.Id,
                Email = entity.Email
            };
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var entity = _ctx.Customers.Update(new CustomerEntity
            {
                Email = customer.Email,
                Id = customer.Id
            }).Entity;

            _ctx.SaveChanges();

            return new Customer
            {
                Email = entity.Email,
                Id = entity.Id
            };
        }
    }
}