using Domain.AggregatesModel.InventoryAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly FerreteriaContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public InventoryRepository(FerreteriaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Inventory Add(Inventory Inventory)
        {
            if (Inventory.IsTransient())
            {
                return _context.Inventories
                    .Add(Inventory)
                    .Entity;
            }
            else
            {
                return Inventory;
            }
        }

        public Inventory Update(Inventory Inventory)
        {
            return _context.Inventories
                    .Update(Inventory)
                    .Entity;
        }

        public async Task<Inventory> GetAsync(Guid InventoryId)
        {
            var inventory = await _context.Inventories
                   .Where(b => b.Id == InventoryId)
                   .FirstOrDefaultAsync();

            return inventory;
        }

        public async Task<Inventory> GetByProductIdAsync(Guid ProductId)
        {
            var inventory = await _context.Inventories
                   .Where(b => b.ProductId == ProductId)
                   .FirstOrDefaultAsync();
            return inventory;
        }

        public Inventory Remove(Inventory Inventory)
        {
            return _context.Inventories
                    .Remove(Inventory)
                    .Entity;
        }

    }
}
