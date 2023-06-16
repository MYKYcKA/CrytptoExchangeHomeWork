using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public class AskDto
{
    [JsonPropertyName("Order")]
    public OrderDto Order { get; set; }
}