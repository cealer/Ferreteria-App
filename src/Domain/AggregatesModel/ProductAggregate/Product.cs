using Domain.Events;
using Domain.Exceptions;
using Domain.SeedWork;

namespace Domain.AggregatesModel.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }

        public Product()
        {
        }

        public Product(string code, string description, string category, decimal price)
        {
            ValidateData(code, description, category, price);
        }

        public void Edit(string code, string description, string category, decimal price)
        {
            ValidateData(code, description, category, price);
        }

        private void ValidateData(string code, string description, string category, decimal price)
        {
            Code = !string.IsNullOrEmpty(code) ? code : throw new FeterriaDomainException($"{nameof(Code)} can't be null"); ;
            Description = !string.IsNullOrEmpty(description) ? description : throw new FeterriaDomainException($"{nameof(Description)} can't be null");
            Category = !string.IsNullOrEmpty(category) ? category : throw new FeterriaDomainException($"{nameof(Category)} can't be null");
            Price = price > 0 ? price : throw new FeterriaDomainException($"{nameof(Price)} must be greater than 0");
        }

        public void Remove()
        {
            AddProductDeletedDomainEvent();
        }

        public void AddProductCreatedDomainEvent()
        {
            this.AddDomainEvent(new ProductCreatedDomainEvent(Id));
        }


        private void AddProductDeletedDomainEvent()
        {
            this.AddDomainEvent(new ProductDeletedDomaintEvent(Id));
        }

    }
}
