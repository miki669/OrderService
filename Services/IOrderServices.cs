using OrderService.Dto;

namespace OrderService.Services;

public interface IOrderServices
{
    Task<EditOrderResponseDto> GetOrderAsync(Guid Id);
    Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task DeleteOrderAsync(Guid Id);
    Task<EditOrderResponseDto> UpdateOrderAsync(Guid Id, EditOrderRequestDto editOrderRequestDto);
}