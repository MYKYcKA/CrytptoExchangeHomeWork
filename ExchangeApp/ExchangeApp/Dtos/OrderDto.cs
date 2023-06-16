using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public class OrderDto
{
    [JsonPropertyName("Id")]
    public object Id { get; set; }

    [JsonPropertyName("Time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("Type")]
    public string Type { get; set; }

    [JsonPropertyName("Kind")]
    public string Kind { get; set; }

    [JsonPropertyName("Amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("Price")]
    public decimal Price { get; set; }
}