using System.Text.Json.Serialization;
using OrderService.Exceptions;

namespace OrderService.Dto;

public class CreateOrderDto
{
    public Guid Id { get; set; }
    
    [JsonPropertyName("status")] 
    public string StatusString
    {
        get { return OrderStatus.New.ToString() ; }
        set
        {
            if (Enum.TryParse(value, true, out OrderStatus orderStatus))
            {
                Status = orderStatus;
            }
            else
            {
                throw new InvalidStatusException($"Invalid value '{value}' for status");
            }
        }
    }

    [JsonIgnore] 
    public DateTime Created { get; set; }
    
    [JsonPropertyName("created")] 
    public string CreatedAsString => Created.ToString("yyyy-MM-dd HH:mm:ss");
    [JsonIgnore]
    public OrderStatus Status { get; set; }
    public List<LinesDto> Lines { get; set; }
}