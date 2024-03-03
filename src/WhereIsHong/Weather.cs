using System.Text.Json.Serialization;

namespace WhereIsHong;

public class Weather
{
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("temperatureApparent")]
    public double TemperatureApparent { get; set; }

    [JsonPropertyName("condition")]
    public string Condition { get; set; }

    [JsonPropertyName("conditionCode")]
    public int ConditionCode { get; set; }

    [JsonPropertyName("windSpeed")]
    public double WindSpeed { get; set; }

    [JsonPropertyName("windGust")]
    public double WindGust { get; set; }

    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }
}



