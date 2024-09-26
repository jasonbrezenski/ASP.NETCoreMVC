using ASP.NETCoreMVC;
using ASP.NETCoreMVC.Models;

namespace ASP.NETCoreMVC.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();

    public Product GetProduct(int id);

    public void UpdateProduct(Product product);

    public void InsertProduct(Product productToInsert);

    public IEnumerable<Category> GetCategories();

    public Product AssignCategory();

    public void DeleteProduct(Product product);
}