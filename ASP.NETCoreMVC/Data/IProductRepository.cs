using ASP.NETCoreMVC;
using ASP.NETCoreMVC.Models;

namespace ASP.NETCoreMVC.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();

    public Product GetProduct(int id);
}