using System.Text.Json.Serialization;

namespace WhereIsHong;

public class Location
{
    [JsonPropertyName("query")]
    public string Query { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}



