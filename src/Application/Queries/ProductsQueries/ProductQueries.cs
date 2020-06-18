using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Queries.ProductsQueries
{
    public class ProductQueries : IProductQueries
    {
        private readonly string _connectionString = string.Empty;

        public ProductQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<ProductViewModel>(
                   @" select p.ProductId,p.Code,p.Description,p.Category, p.Price,i.Stock from Inventories i Inner join Products p on i.ProductId=p.ProductId");

                if (result.AsList().Count == 0)
                    new List<ProductViewModel>();

                return result.ToList();
            }
        }

        public async Task<List<ProductViewModel>> GetByFilterAsync(string filter)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<ProductViewModel>(
                   @"select p.ProductId,p.Code,p.Description,p.Category, p.Price,i.Stock from Inventories i Inner join Products p on i.ProductId=p.ProductId where code LIKE CONCAT('%', @filter, '%') || description like CONCAT ('%',@filter,'%'); ",
                   new { filter });

                if (result.AsList().Count == 0)
                    new List<ProductViewModel>();

                return result.ToList();
            }
        }

    }
}
