using Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateProductCommand message, CancellationToken cancellationToken)
        {
            var product = new Product(message.Code, message.Description, message.Category, message.Price);
            _productRepository.Add(product);
            product.AddProductCreatedDomainEvent();
            _logger.LogInformation("----- Creating Product - product: {@Product}", product);

            return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
