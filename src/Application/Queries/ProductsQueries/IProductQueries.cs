using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.ProductsQueries
{
    public interface IProductQueries
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task<List<ProductViewModel>> GetByFilterAsync(string filter);
    }
}
