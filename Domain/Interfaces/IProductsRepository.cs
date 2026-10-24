using Domain.Models;

namespace Domain.Interfaces;

public interface IProductsRepository
{
    void AddProduct(Product product);
    void DeleteProduct(int id);
    void UpdateProduct(Product product);
    Product GetProduct(int id);
    List<Product> GetProducts();
    List<Product> GetProductByCategory(string name);
}
