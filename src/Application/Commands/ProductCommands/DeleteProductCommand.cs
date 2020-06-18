using MediatR;
using System;
using System.Runtime.Serialization;

namespace Application.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        [DataMember]
        public Guid ProductId { get; private set; }
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
