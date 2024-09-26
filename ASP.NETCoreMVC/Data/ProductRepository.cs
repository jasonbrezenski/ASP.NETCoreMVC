using System.Data;
using ASP.NETCoreMVC.Models;
using Dapper;

namespace ASP.NETCoreMVC.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public Product GetProduct(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id", new { id = id });
    }
}