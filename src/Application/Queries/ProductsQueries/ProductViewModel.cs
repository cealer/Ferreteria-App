using System;

namespace Application.Queries.ProductsQueries
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Stock { get; set; }
    }
}
