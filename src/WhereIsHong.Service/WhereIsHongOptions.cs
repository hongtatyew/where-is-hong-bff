using System.ComponentModel.DataAnnotations;

namespace WhereIsHong.Services;

public record WhereIsHongOptions
{
    [Required]
    public Guid JournalId { get; set; } = Guid.Empty;
}