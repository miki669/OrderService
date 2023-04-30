using OrderService.Dto;

namespace OrderService.Services;

public interface IProductServices
{
    Task<ResnoseProductDto> GetProductAsync(Guid Id);
    Task<ResnoseProductDto> CreateProductAsync(RequestProductDto productdtp);
    Task<ResnoseProductDto> UpdateProductAsync(Guid Id, RequestProductDto productDto);
    Task DeleteProductAsync(Guid Id);
}