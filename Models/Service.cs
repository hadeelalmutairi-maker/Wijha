using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("services")]
public class Service
{
    public static readonly string[] Fillable =
    {
        "service_name", "service_description", "icon_url", "is_active",
    };

    [Key]
    [Column("service_id")]
    public int ServiceId { get; set; }

    [Column("service_name")]
    [MaxLength(100)]
    public string ServiceName { get; set; } = string.Empty;

    [Column("service_description")]
    [MaxLength(500)]
    public string? ServiceDescription { get; set; }

    [Column("icon_url")]
    [MaxLength(255)]
    public string? IconUrl { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    public ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    [NotMapped]
    public int ProviderCount { get; set; }

    [NotMapped]
    public decimal? FromPrice { get; set; }

    [NotMapped]
    public int ProviderServicesCount { get; set; }
}
