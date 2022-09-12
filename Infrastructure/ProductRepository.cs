using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    public List<Product> GetAllProducts()
    {
        return new List<Product>() { new Product() { Id = 1, Name = "Mock Product", Price = 42 } };
    }
}