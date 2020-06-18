using MediatR;
using System.Runtime.Serialization;

namespace Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<bool>
    {
        [DataMember]
        public string Code { get; private set; }
        [DataMember]

        public string Description { get; private set; }
        [DataMember]

        public string Category { get; private set; }
        [DataMember]

        public decimal Price { get; private set; }

        public CreateProductCommand(string code, string description, string category, decimal price)
        {
            Code = code;
            Description = description;
            Category = category;
            Price = price;
        }

    }
}
