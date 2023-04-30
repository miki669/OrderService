using Microsoft.EntityFrameworkCore;
using OrderService.Context;
using OrderService.Dto;
using OrderService.Exceptions;

namespace OrderService.Services;

public class OrderServices : IOrderServices
{
    private readonly PrimaryDataBaseContext _context;


    public OrderServices(PrimaryDataBaseContext context)
    {
        _context = context;
    }

    public async Task<EditOrderResponseDto> GetOrderAsync(Guid Id)
    {
        var order = await _context.Orders.Include(p => p.OrderProducts).FirstOrDefaultAsync(p => p.Id == Id);
        if (order is null)
            throw new OrderNotFoundException($"Order with id: {Id} not found!");
        return new EditOrderResponseDto()
        {
            Id = order.Id,
            OrderStatus = order.Status,
            Created = order.Сreated,
            Lines = order.OrderProducts.Select(p => new LinesDto()
            {
                Id = p.Id, Qty = p.Qty
            }).ToList()
        };
    }


    public async Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        if (_context.Orders.Any(p => p.Id == createOrderDto.Id))
            throw new OrderExistException($"Order with id: {createOrderDto.Id} exist!");

        var order = new Order()
        {
            Id = createOrderDto.Id,
            Status = OrderStatus.New,
            Сreated = DateTime.UtcNow,
            OrderProducts = new List<OrderProduct>()
        };
        foreach (var item in createOrderDto.Lines)
        {
            if (item.Qty <= 0)
                continue;
            /*
             в случае, если нужно кидать исключение
             if (item.Qty <= 0)
               throw new NegativeOrZeroQuantityException("Order line quantity cannot be negative or zero");
             */
            var orderProduct = new OrderProduct()
            {
                Product = new Product()
                {
                    Id = item.Id,
                   
                },
                Qty = item.Qty
            };
            _context.Attach(orderProduct.Product);
            order.OrderProducts.Add(orderProduct);
        }

        if (order.OrderProducts.Count == 0)
            throw new ZeroQuantityException("Line cannot be zero");
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return new CreateOrderDto
        {
            Id = order.Id,
            Status = order.Status,
            Created = order.Сreated,
            Lines = order.OrderProducts.Select(p => new LinesDto()
            {
                Id = p.Product.Id,
                Qty = p.Qty
            }).ToList()
        };
    }

    public async Task<EditOrderResponseDto> UpdateOrderAsync(Guid Id, EditOrderRequestDto editOrderRequestDto)
    {
        var order = await _context.Orders
            .Include(p => p.OrderProducts)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == Id);

        if (order is null)
            throw new OrderNotFoundException($"Order with id: {Id} not found!");
        if (order.Status > OrderStatus.WaitingForPayment)
            throw new OrderDeletionException(
                "Cannot edit an order in the 'Paid', 'InDelivery', 'Delivered' or 'Completed' status.");


        foreach (var item in editOrderRequestDto.Lines)
        {
            if (item.Qty <= 0)
                continue;
            /*
         в случае, если нужно кидать исключение
         if (item.Qty <= 0)
           throw new NegativeOrZeroQuantityException("Order line quantity cannot be negative or zero");
           */
            if (order.OrderProducts.Any(op => op.Product.Id == item.Id))
                continue;
            var orderProduct = new OrderProduct()
            {
                Product = new Product()
                {
                    Id = item.Id
                },
                Order = order,
                Qty = item.Qty
            };
            _context.Attach(orderProduct.Product);
            order.OrderProducts.Add(orderProduct);
        }

        order.Status = editOrderRequestDto.OrderStatus;
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return new EditOrderResponseDto
        {
            Id = order.Id,
            Created = order.Сreated,
            OrderStatus = order.Status,
            Lines = order.OrderProducts.Select(p => new LinesDto()
            {
                Id = p.Id, Qty = p.Qty
            }).ToList()
        };
    }

    public async Task DeleteOrderAsync(Guid Id)
    {
        var order = await _context.Orders.FindAsync(Id);
        if (order is null)
            throw new OrderNotFoundException($"Order with id: {Id} not found!");
        if (order.Status > OrderStatus.Paid)
            throw new OrderDeletionException(
                "Cannot delete an order in the 'InDelivery', 'Delivered' or 'Completed' status.");
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}