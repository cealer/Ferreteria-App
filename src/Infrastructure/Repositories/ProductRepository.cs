using Domain.AggregatesModel.ProductAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FerreteriaContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ProductRepository(FerreteriaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product Add(Product product)
        {
            if (product.IsTransient())
            {
                return _context.Products
                    .Add(product)
                    .Entity;
            }
            else
            {
                return product;
            }
        }

        public Product Update(Product product)
        {
            return _context.Products
                    .Update(product)
                    .Entity;
        }

        public Product Remove(Product product)
        {
            return _context.Products
                    .Remove(product)
                    .Entity;
        }

        public async Task<Product> GetAsync(Guid ProductId)
        {
            var wallet = await _context.Products
                   .Where(b => b.Id == ProductId)
                   .FirstOrDefaultAsync();

            return wallet;
        }

    }
}
