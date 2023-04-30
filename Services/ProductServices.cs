using Microsoft.EntityFrameworkCore;
using OrderService.Context;
using OrderService.Dto;
using OrderService.Exceptions;

namespace OrderService.Services;

public class ProductServices : IProductServices
{
    private readonly PrimaryDataBaseContext _context;

    public ProductServices(PrimaryDataBaseContext context)
    {
        _context = context;
    }

    public async Task<ResnoseProductDto> GetProductAsync(Guid Id)
    {
        var product = await _context.Products.FindAsync(Id);
        if (product is null)
            throw new ProductNotFoundException($"Product with id: {Id} not found!");
        return new ResnoseProductDto
        {
            Id = product.Id,
            Description = product.Description,
            Name = product.Name,
            Code = product.Code,
            Price = product.Price
        };
    }

    public async Task<ResnoseProductDto> CreateProductAsync(RequestProductDto productdto)
    {
        var Product = new Product()
        {
            Description = productdto.Description,
            Name = productdto.Name,
            Code = productdto.Code,
            Price = productdto.Price,
        };
        _context.Products.Add(Product);
        _context.SaveChanges();
        return new ResnoseProductDto()
        {
            Id = Product.Id,
            Description = Product.Description,
            Name = Product.Name,
            Code = Product.Code,
            Price = Product.Price
        };
    }

    public async Task<ResnoseProductDto> UpdateProductAsync(Guid Id, RequestProductDto productDto)
    {
        var product = await _context.Products
            .FindAsync(Id);
        if (product is null)
            throw new ProductNotFoundException($"Product with id: {Id} not found!");
        product.Code = productDto.Code;
        product.Description = productDto.Description;
        product.Name = productDto.Name;
        product.Price = productDto.Price;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return new ResnoseProductDto()
        {
            Description = product.Description,
            Code = product.Code,
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };
    }

    public async Task DeleteProductAsync(Guid Id)
    {
        var product = await _context.Products.FindAsync(Id);
        if(product is null)
            throw new ProductNotFoundException($"Product with id: {Id} not found!");
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}