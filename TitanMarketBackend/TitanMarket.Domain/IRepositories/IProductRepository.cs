using System.Collections.Generic;
using TitanMarket.Core.Models;

namespace TitanMarket.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product CreateProduct(Product product);
        
        Product UpdateProduct(int productId, Product product);

        void DeleteProduct(int productId);
    }
}