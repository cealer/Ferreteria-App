using Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.InventoryAggregate
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Inventory Add(Inventory inventory);

        Inventory Update(Inventory inventory);

        Task<Inventory> GetAsync(Guid InventoryId);

        Task<Inventory> GetByProductIdAsync(Guid ProductId);

        Inventory Remove(Inventory Inventory);

    }
}
