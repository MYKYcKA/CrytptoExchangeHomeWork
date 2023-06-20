using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public class OrderBookDto
{
    [JsonPropertyName("AcqTime")]
    public DateTime AcqTime { get; set; }

    [JsonPropertyName("Bids")]
    public List<BidDto> Bids { get; set; }

    [JsonPropertyName("Asks")]
    public List<AskDto> Asks { get; set; }
}