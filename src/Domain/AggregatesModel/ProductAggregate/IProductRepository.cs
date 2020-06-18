using Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);

        Product Update(Product product);

        Product Remove(Product product);

        Task<Product> GetAsync(Guid ProductId);
    }
}
