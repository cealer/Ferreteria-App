using Application.Commands.InventoryCommands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Validations
{
    public class AddQuantityInventoryCommandValidator : AbstractValidator<AddQuantityInventoryCommand>
    {
        public AddQuantityInventoryCommandValidator(ILogger<AddQuantityInventoryCommand> logger)
        {
            RuleFor(command => command.ProductId).NotEqual(Guid.Empty).WithMessage("Product Invalid");
            RuleFor(command => command.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0"); ;
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
