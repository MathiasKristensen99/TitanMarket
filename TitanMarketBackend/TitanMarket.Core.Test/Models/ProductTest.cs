using TitanMarket.Core.Models;
using Xunit;

namespace TitanMarket.Core.Test.Models
{
    public class ProductTest
    {
        [Fact]
        public void ProductExists()
        {
            var product = new Product();
            Assert.NotNull(product);
        }
    }
}