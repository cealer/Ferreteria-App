using Domain.AggregatesModel.InventoryAggregate;
using System;
using Xunit;

namespace UnitTests.Domain
{
    public class InventoryAggregateTest
    {
        public Inventory CreateInventory()
        {
            //Arrange
            var stock = 0;
            var productId = Guid.NewGuid();

            //Act
            return new Inventory(stock, productId);
        }

        [Fact]
        public void Create_Inventory_success()
        {
            //Arrange
            var stock = 0;
            var productId = Guid.NewGuid();

            //Act
            var inventory = new Inventory(stock, productId);
            //Assert
            Assert.Equal(stock, inventory.Stock);
            Assert.Equal(productId, inventory.ProductId);
        }

        [Fact]
        public void Add_Quantity_success()
        {
            //Arrange
            var quantity = 10;

            //Act
            var inventory = CreateInventory();
            inventory.AddStock(quantity);
            //Assert
            Assert.Equal(quantity, inventory.Stock);
        }
    }
}
