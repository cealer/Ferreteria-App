using MediatR;
using System;

namespace Domain.Events
{
    public class ProductCreatedDomainEvent : INotification
    {
        public Guid ProductId { get; }

        public ProductCreatedDomainEvent(Guid productId)
        {
            ProductId = productId;
        }
    }
}
