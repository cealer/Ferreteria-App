using Domain.AggregatesModel.InventoryAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.InventoryCommands
{
    public class AddQuantityInventoryCommandHandler : IRequestHandler<AddQuantityInventoryCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<AddQuantityInventoryCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public AddQuantityInventoryCommandHandler(
            IInventoryRepository inventoryRepository,
            ILogger<AddQuantityInventoryCommandHandler> logger)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(AddQuantityInventoryCommand message, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(message.ProductId);

            inventory.AddStock(message.Quantity);
            _logger.LogInformation("----- adding Inventory - iventory: {@Inventory}", inventory);

            return await _inventoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
