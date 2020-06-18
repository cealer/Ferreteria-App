using Domain.AggregatesModel.InventoryAggregate;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEventHandlers
{
    public class ProductCreatedDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILoggerFactory _logger;
        public ProductCreatedDomainEventHandler(IInventoryRepository inventoryRepository, ILoggerFactory logger)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            int initialStock = 0;
            var newInventory = new Inventory(initialStock, notification.ProductId);
            _inventoryRepository.Add(newInventory);

            _logger.CreateLogger("----- Creating Inventory - iventory");

            await _inventoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
