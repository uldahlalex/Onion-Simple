using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public List<Product> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }
}