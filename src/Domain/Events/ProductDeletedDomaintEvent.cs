using MediatR;
using System;

namespace Domain.Events
{
    public class ProductDeletedDomaintEvent : INotification
    {
        public Guid ProductId { get; }

        public ProductDeletedDomaintEvent(Guid productId)
        {
            ProductId = productId;
        }
    }
}
