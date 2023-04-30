using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime Сreated { get; set; } = DateTime.UtcNow;
    public List<OrderProduct> OrderProducts { get; set; }


}
public enum OrderStatus
{
    New,
    WaitingForPayment,
    Paid,
    InDelivery,
    Delivered,
    Completed
}