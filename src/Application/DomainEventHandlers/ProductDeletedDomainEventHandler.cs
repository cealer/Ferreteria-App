using Domain.AggregatesModel.InventoryAggregate;
using Domain.AggregatesModel.ProductAggregate;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEventHandlers
{
    public class ProductDeletedDomainEventHandler : INotificationHandler<ProductDeletedDomaintEvent>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILoggerFactory _logger;
        public ProductDeletedDomainEventHandler(IInventoryRepository inventoryRepository, ILoggerFactory logger,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(ProductDeletedDomaintEvent notification, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(notification.ProductId);

            _inventoryRepository.Remove(inventory);

            _logger.CreateLogger("----- Deleting Inventory - iventory");

            var producto = await _productRepository.GetAsync(notification.ProductId);

            _productRepository.Remove(producto);

            await _inventoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
