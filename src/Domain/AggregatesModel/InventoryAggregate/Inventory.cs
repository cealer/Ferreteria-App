using Domain.Exceptions;
using Domain.SeedWork;
using System;

namespace Domain.AggregatesModel.InventoryAggregate
{
    public class Inventory : Entity, IAggregateRoot
    {
        public Guid ProductId { get; private set; }
        public int Stock { get; private set; }

        public Inventory()
        {
        }

        public Inventory(int stock, Guid productId) : this()
        {
            ProductId = productId;
            Stock = stock;
        }

        public void AddStock(int Quantity)
        {
            if (Quantity > 0)
            {
                Stock += Quantity;
                return;
            }
            throw new FeterriaDomainException("Invalid Quantity");
        }

    }
}
