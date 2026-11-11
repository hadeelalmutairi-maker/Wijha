using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("provider_services")]
public class ProviderService
{
    public static readonly string[] Fillable =
    {
        "provider_id", "service_id", "service_category_id", "offering_title",
        "offering_description", "price", "price_unit", "duration_hours",
        "portfolio_url", "service_city", "is_active",
    };

    [Key]
    [Column("provider_service_id")]
    public int ProviderServiceId { get; set; }

    [Column("provider_id")]
    public int ProviderId { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }

    [Column("service_category_id")]
    public int? ServiceCategoryId { get; set; }

    [Column("offering_title")]
    [MaxLength(150)]
    public string OfferingTitle { get; set; } = string.Empty;

    [Column("offering_description")]
    [MaxLength(1000)]
    public string? OfferingDescription { get; set; }

    [Column("price", TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Column("price_unit")]
    [MaxLength(20)]
    public string PriceUnit { get; set; } = "Fixed";

    [Column("duration_hours", TypeName = "decimal(4,1)")]
    public decimal? DurationHours { get; set; }

    [Column("portfolio_url")]
    [MaxLength(255)]
    public string? PortfolioUrl { get; set; }

    [Column("service_city")]
    [MaxLength(60)]
    public string ServiceCity { get; set; } = string.Empty;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public ServiceProvider ServiceProvider { get; set; } = null!;

    public Service Service { get; set; } = null!;

    public ServiceCategory? ServiceCategory { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
