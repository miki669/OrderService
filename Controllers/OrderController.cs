using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OrderService;
using OrderService.Context;
using OrderService.Controllers;
using OrderService.Dto;
using OrderService.Services;

namespace OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderServices _orderServices;

    public OrderController(ILogger<OrderController> logger, IOrderServices orderServices)
    {
        _orderServices = orderServices;
        _logger = logger;
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<EditOrderResponseDto> Get(Guid id)
    {
        return await _orderServices.GetOrderAsync(id);
    }

    // POST: api/Orders
    [HttpPost]
    public async Task<CreateOrderDto> CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        return await _orderServices.CreateOrderAsync(createOrderDto);
    }

    // PUT: api/Orders/5
    [HttpPut("{id:guid}")]
    public async Task<EditOrderResponseDto> Put(Guid id, [FromBody] EditOrderRequestDto editOrderRequestDto)
    {
        return await _orderServices.UpdateOrderAsync(id, editOrderRequestDto);
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _orderServices.DeleteOrderAsync(id);
    }
}