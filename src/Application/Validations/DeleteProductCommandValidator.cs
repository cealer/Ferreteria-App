using Application.Commands.ProductCommands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Validations
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator(ILogger<DeleteProductCommand> logger)
        {
            RuleFor(command => command.ProductId).NotEqual(Guid.Empty).WithMessage("Product Invalid");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

    }
}
