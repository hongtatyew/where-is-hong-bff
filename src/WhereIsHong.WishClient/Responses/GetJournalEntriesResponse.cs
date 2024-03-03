using System.Text.Json.Serialization;

namespace WhereIsHong.WishClient;

public record GetJournalEntriesResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("condition")]
    public string Condition { get; set; }

    [JsonPropertyName("conditionCode")]
    public int ConditionCode { get; set; }

    [JsonPropertyName("query")]
    public string Query { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }
}
