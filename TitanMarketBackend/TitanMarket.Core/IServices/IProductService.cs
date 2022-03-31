using System.Collections.Generic;
using TitanMarket.Core.Models;

namespace TitanMarket.Core.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product CreateProduct(Product product);

        Product UpdateProduct(int productId, Product product);

        void DeleteProduct(int productId);

        List<Product> GetProductsBySearch(string name);

    }
}