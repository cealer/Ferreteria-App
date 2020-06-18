using Application.Commands.ProductCommands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Validations
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator(ILogger<EditProductCommand> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
            RuleFor(command => command.ProductId).NotEqual(Guid.Empty).WithMessage("Product Invalid");
            RuleFor(command => command.Category).NotNull();
            RuleFor(command => command.Code).NotEmpty();
            RuleFor(command => command.Description).MaximumLength(20);
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.Description).MaximumLength(100);
            RuleFor(command => command.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(command => command.Price).LessThan(999999.99m).WithMessage("Price must be less than 999999.99");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

    }
}
