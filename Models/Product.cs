using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    
    public List<OrderProduct> OrderProducts { get; set; }
    /*
      public List<string> Images { get; set; }
      public List<Characteristic> Characteristics { get; set; }
      public Category Category { get; set; }
      public string Brand { get; set; }
      public string CountryOfManufacture { get; set; }
      public int StockQuantity { get; set; }
      public ShippingAndPaymentInfo ShippingAndPaymentInfo { get; set; }
      public List<CustomerReview> CustomerReviews { get; set; }
      public WarrantyAndReturnInfo WarrantyAndReturnInfo { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
    */
}

public class Characteristic
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class Category
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class ShippingAndPaymentInfo
{
    public string ShippingInfo { get; set; }
    public string PaymentInfo { get; set; }
}

public class CustomerReview
{
    public string Author { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class WarrantyAndReturnInfo
{
    public string WarrantyInfo { get; set; }
    public string ReturnInfo { get; set; }
}