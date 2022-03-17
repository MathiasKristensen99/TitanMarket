using Moq;
using TitanMarket.Domain.IRepositories;
using Xunit;

namespace TitanMarket.Domain.Test.IRepositories
{
    public class IProductRepositoryTest
    {
        [Fact]
        public void IProductRepositoryExists()
        {
            var productRepository = new Mock<IProductRepository>();
            Assert.NotNull(productRepository);
        }
    }
}