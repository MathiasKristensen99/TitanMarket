using System.Collections.Generic;
using TitanMarket.Core.IServices;
using TitanMarket.Core.Models;
using TitanMarket.Domain.IRepositories;

namespace TitanMarket.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }
        
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product UpdateProduct(int productId, Product product)
        {
            return _productRepository.UpdateProduct(productId, product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}