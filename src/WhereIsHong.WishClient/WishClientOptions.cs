using System.ComponentModel.DataAnnotations;

namespace WhereIsHong.WishClient;

public record WishClientOptions
{
    [Required, Url]
    public string BaseUrl { get; set; } = string.Empty;

    [Required, MinLength(1)]
    public string Authorization { get; set; } = string.Empty;

    [Required, MinLength(1)]
    public string ApiKey { get; set; } = string.Empty;
}
