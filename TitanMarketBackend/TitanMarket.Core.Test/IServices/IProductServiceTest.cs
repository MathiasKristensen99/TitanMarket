using Moq;
using TitanMarket.Core.IServices;
using Xunit;

namespace TitanMarket.Core.Test.IServices
{
    public class IProductServiceTest
    {
        [Fact]
        public void IProductServiceExists()
        {
            var serviceMock = new Mock<IProductService>();
            Assert.NotNull(serviceMock);
        }
    }
}