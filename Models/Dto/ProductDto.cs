namespace OrderService.Dto;

public class RequestProductDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

public class ResnoseProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}