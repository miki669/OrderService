using System.Text.Json.Serialization;

namespace OrderService.Dto;

public class EditOrderRequestDto
{
    [JsonPropertyName("status")]
    public string StatusString
    {
        get { return OrderStatus.ToString(); }
        set { OrderStatus = Enum.Parse<OrderStatus>(value, true); }
    }
    [JsonIgnore] 
    public OrderStatus OrderStatus { get; set; }
    
    public List<LinesDto> Lines { get; set; }
}
public class EditOrderResponseDto
{
    public Guid Id { get; set; }

    [JsonPropertyName("status")]
    public string StatusString
    {
        get { return OrderStatus.ToString(); }
        set { OrderStatus = Enum.Parse<OrderStatus>(value, true); }
    }
    public DateTime Created { get; set; }
    [JsonIgnore] 
    public OrderStatus OrderStatus { get; set; }
    public List<LinesDto> Lines { get; set; }
}