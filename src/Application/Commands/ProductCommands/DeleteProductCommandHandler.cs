using Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public DeleteProductCommandHandler(
            IProductRepository productRepository,
            ILogger<DeleteProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteProductCommand message, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(message.ProductId);
            product.Remove();
            await _productRepository.UnitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
