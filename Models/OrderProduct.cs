using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService;

public class OrderProduct
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public int Qty { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}