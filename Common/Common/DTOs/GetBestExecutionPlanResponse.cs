using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Common.DTOs;

[DataContract]
public class GetBestExecutionPlanResponse
{
    [JsonPropertyName("ErrorMsg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorMsg { get; set; }

    [JsonPropertyName("TotalPrice")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public decimal TotalPrice { get; set; }

    [JsonPropertyName("ExecutionPlan")]
    public List<Order> ExecutionPlan { get; set; } = new List<Order>();
}