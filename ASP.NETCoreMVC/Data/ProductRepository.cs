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

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new { name = product.Name, price = product.Price, id = product.ProductID });
    }

    public void InsertProduct(Product productToInsert)
    {
        _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
            new
            { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _connection.Query<Category>("SELECT * FROM categories;");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }

    public void DeleteProduct(Product product)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id = product.ProductID });
        _connection.Execute("DELETE FROM sales WHERE ProductID = @id;", new { id = product.ProductID });
        _connection.Execute("DELETE FROM products WHERE ProductID = @id;", new { id = product.ProductID });
    }
}