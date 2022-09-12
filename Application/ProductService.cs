using Application.Interfaces;
using Domain;
using Domain.Interfaces;

namespace Application;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    
    public ProductService(IProductRepository repository)
    {
        _productRepository = repository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }
}