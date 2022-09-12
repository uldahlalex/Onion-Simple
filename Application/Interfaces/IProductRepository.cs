using Domain;

namespace Application.Interfaces;

public interface IProductRepository
{
    public List<Product> GetAllProducts();
}