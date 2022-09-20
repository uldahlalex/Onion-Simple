using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<PostProductDTO> _postValidator;
    private readonly IValidator<Product> _productValidator;
    private readonly IMapper _mapper;


    public ProductService(
        IProductRepository repository,
        IValidator<PostProductDTO> postValidator,
        IValidator<Product> productValidator,
        IMapper mapper)
    {
        _mapper = mapper;
        _postValidator = postValidator;
        _productValidator = productValidator;
        _productRepository = repository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product CreateNewProduct(PostProductDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _productRepository.CreateNewProduct(_mapper.Map<Product>(dto));

    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void RebuildDB()
    {
        _productRepository.RebuildDB();
    }

    public Product UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _productValidator.Validate(product);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _productRepository.UpdateProduct(product);

    }

    public Product DeleteProduct(int id)
    {
        return _productRepository.DeleteProduct(id);
    }

}