using System.IO;
using Moq;
using TitanMarket.Core.IServices;
using TitanMarket.Domain.IRepositories;
using TitanMarket.Domain.Services;
using Xunit;

namespace TitanMarket.Domain.Test.Services
{
    public class ProductServiceTest
    {
        [Fact]
        public void ProductService_IsIProductService()
        {
            var repoMock = new Mock<IProductRepository>();
            var productService = new ProductService(repoMock.Object);
            Assert.IsAssignableFrom<IProductService>(productService);
        }

        [Fact]
        public void GetAll_NoParams_CallsAccountRepositoryOnce()
        {
            // arrange
            var repoMock = new Mock<IProductRepository>();
            var productService = new ProductService(repoMock.Object);

            // act
            productService.GetAllProducts();
            
            // assert
            repoMock.Verify(repository => repository.GetAllProducts(), Times.Once);
        }
    }
}