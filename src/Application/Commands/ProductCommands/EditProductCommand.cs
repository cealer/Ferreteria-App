using MediatR;
using System;
using System.Runtime.Serialization;

namespace Application.Commands.ProductCommands
{
    public class EditProductCommand : IRequest<bool>
    {
        [DataMember]

        public Guid ProductId { get; private set; }
        [DataMember]

        public string Code { get; private set; }
        [DataMember]

        public string Description { get; private set; }
        [DataMember]

        public string Category { get; private set; }
        [DataMember]

        public decimal Price { get; private set; }

        public EditProductCommand(Guid productId, string code, string description, string category, decimal price)
        {
            ProductId = productId;
            Code = code;
            Description = description;
            Category = category;
            Price = price;
        }
    }
}
