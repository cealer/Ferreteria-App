using MediatR;
using System;
using System.Runtime.Serialization;

namespace Application.Commands.InventoryCommands
{
    public class AddQuantityInventoryCommand : IRequest<bool>
    {
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public Guid ProductId { get; set; }


        public AddQuantityInventoryCommand(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
