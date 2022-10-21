using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{

    private readonly DatabaseContext _context; 
    
    public ProductRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public List<Product> GetAllProducts()
    {
        return _context.ProductTable.ToList();
    }

    public Product CreateNewProduct(Product product)
    {
        _context.ProductTable.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product GetProductById(int id)
    {
        return _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
    
    public Product UpdateProduct(Product product)
    {
        _context.ProductTable.Update(product);
        _context.SaveChanges();
        return product;
    }

    public Product DeleteProduct(int id)
    {
        var productToDelete = _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
        _context.ProductTable.Remove(productToDelete);
        _context.SaveChanges();
        return productToDelete;
    }
}