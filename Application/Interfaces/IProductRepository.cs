using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IProductRepository
{
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(Product product);
    public Product GetProductById(int id);
    public void RebuildDB();
    public Product UpdateProduct(Product product);
    public Product DeleteProduct(int id);
}
