using Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<EditProductCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public EditProductCommandHandler(
            IProductRepository productRepository,
            ILogger<EditProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(EditProductCommand message, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(message.ProductId);

            product.Edit(message.Code, message.Description, message.Category, message.Price);

            _productRepository.Update(product);

            _logger.LogInformation("----- Creating Product - product: {@Product}", product);

            return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
