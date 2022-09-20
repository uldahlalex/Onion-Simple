
using Application.DTOs;

namespace Domain.Interfaces;

public interface IProductService
{
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(PostProductDTO dto);
    public Product GetProductById(int id);
    public void RebuildDB();
    public Product UpdateProduct(int id, Product product);
    public Product DeleteProduct(int id);
}