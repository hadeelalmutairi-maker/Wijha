using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("service_categories")]
public class ServiceCategory
{
    public static readonly string[] Fillable =
    {
        "provider_id", "category_name", "category_description", "display_order", "is_active",
    };

    [Key]
    [Column("service_category_id")]
    public int ServiceCategoryId { get; set; }

    [Column("provider_id")]
    public int ProviderId { get; set; }

    [Column("category_name")]
    [MaxLength(100)]
    public string CategoryName { get; set; } = string.Empty;

    [Column("category_description")]
    [MaxLength(500)]
    public string? CategoryDescription { get; set; }

    [Column("display_order")]
    public int DisplayOrder { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    public ServiceProvider ServiceProvider { get; set; } = null!;

    public ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    [NotMapped]
    public int ProviderServicesCount { get; set; }
}
