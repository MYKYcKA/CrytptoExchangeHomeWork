using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public class GetBestExecutionPlanResponse
{
    [JsonPropertyName("TotalPrice")]
    public decimal TotalPrice { get; set; }

    [JsonPropertyName("ExecutionPlan")]
    public List<Order> ExecutionPlan { get; set; } = new List<Order>();
}