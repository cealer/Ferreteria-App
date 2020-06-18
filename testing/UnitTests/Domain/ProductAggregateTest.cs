using Domain.AggregatesModel.ProductAggregate;
using Xunit;

namespace UnitTests.Domain
{
    public class ProductAggregateTest
    {

        public Product CreateProduct()
        {
            //Arrange
            var code = "0001";
            var description = "producto 1";
            var category = "category 123";
            var price = 20;

            //Act
            return new Product(code, description, category, price);
        }

        [Fact]
        public void Create_Product_success()
        {
            //Arrange
            var code = "0001";
            var description = "producto 1";
            var category = "category 123";
            var price = 20;

            //Act
            var product = new Product(code, description, category, price);
            //Assert
            Assert.Equal(code, product.Code);
            Assert.Equal(description, product.Description);
            Assert.Equal(category, product.Category);
            Assert.Equal(price, product.Price);
        }

        [Fact]
        public void Edit_Product_success()
        {
            //Arrange
            var code = "0002";
            var description = "producto 2";
            var category = "category 1234";
            var price = 10;

            //Act
            var product = CreateProduct();
            product.Edit(code, description, category, price);
            //Assert
            Assert.Equal(code, product.Code);
            Assert.Equal(description, product.Description);
            Assert.Equal(category, product.Category);
            Assert.Equal(price, product.Price);
        }


    }
}
