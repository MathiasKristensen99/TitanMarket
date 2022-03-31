using System;
using System.Collections.Generic;
using System.Linq;
using TitanMarket.Core.Models;
using TitanMarket.DB.Entities;
using TitanMarket.Domain.IRepositories;

namespace TitanMarket.DB.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TitanMarketDbContext _ctx;

        public ProductRepository(TitanMarketDbContext context)
        {
            _ctx = context;
        }
        
        public List<Product> GetAllProducts()
        {
            return _ctx.Products.Select(entity => new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            }).ToList();
        }

        public Product CreateProduct(Product product)
        {
            var beforeSave = new ProductEntity
            {
                Name = product.Name,
                Price = product.Price
            };
            var afterSave = _ctx.Products.Add(beforeSave).Entity;
            _ctx.SaveChanges();
            return new Product
            {
                Id = afterSave.Id,
                Name = afterSave.Name,
                Price = afterSave.Price
            };
        }

        public Product UpdateProduct(int productId, Product product)
        {
            var productEntityToUpdate = _ctx.Products
                .FirstOrDefault(pe => pe.Id == productId);

            if (productEntityToUpdate == null)
            {
                throw new NullReferenceException(" Noget gik galt prøv igen");
            }
            
            var updatedProductEntity = new ProductEntity
            {
                Name = product.Name,
                Price = product.Price
            };
            _ctx.Remove(productEntityToUpdate);
            _ctx.Products.Add(updatedProductEntity);
            _ctx.SaveChanges();
            
            return new Product
            {
                Name = updatedProductEntity.Name,
                Price = updatedProductEntity.Price
            };
        }

        public void DeleteProduct(int productId)
        {
            var productEntity = _ctx.Products
                .FirstOrDefault(pe => pe.Id == productId);

            if (productEntity == null)
            {
                throw new NullReferenceException("Vælg et product som skal slettes");
            }

            _ctx.Products.Remove(productEntity);
            _ctx.SaveChanges();
        }

        public List<Product> GetProductsBySearch(string name)
        {
            return _ctx.Products.Select(entity => new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            }).Where(pr => pr.Name.Contains(name)).ToList();
        }
    }
}