using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public class AskDto
{
    [JsonPropertyName("Order")]
    public OrderDto Order { get; set; }
}

[DataContract]
public class Order
{
    [JsonPropertyName("Amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("Price")]
    public decimal Price { get; set; }
}