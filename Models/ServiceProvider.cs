using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Wijha.Models;

[Table("service_providers")]
public class ServiceProvider : IAuthenticatable
{
    public static readonly string[] Fillable =
    {
        "admin_id", "business_name", "owner_name", "email", "password_hash", "phone",
        "city", "business_address", "business_description", "commercial_register_no",
        "logo_url", "approval_status", "account_status",
        "subscription_start_date", "subscription_end_date",
        "average_rating", "total_reviews",
    };

    [Key]
    [Column("provider_id")]
    public int ProviderId { get; set; }

    [Column("admin_id")]
    public int? AdminId { get; set; }

    [Column("business_name")]
    [MaxLength(150)]
    public string BusinessName { get; set; } = string.Empty;

    [Column("owner_name")]
    [MaxLength(100)]
    public string OwnerName { get; set; } = string.Empty;

    [Column("email")]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    [Column("password_hash")]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("phone")]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Column("city")]
    [MaxLength(60)]
    public string City { get; set; } = string.Empty;

    [Column("business_address")]
    [MaxLength(255)]
    public string BusinessAddress { get; set; } = string.Empty;

    [Column("business_description")]
    [MaxLength(1000)]
    public string? BusinessDescription { get; set; }

    [Column("commercial_register_no")]
    [MaxLength(20)]
    public string CommercialRegisterNo { get; set; } = string.Empty;

    [Column("logo_url")]
    [MaxLength(255)]
    public string? LogoUrl { get; set; }

    [Column("average_rating", TypeName = "decimal(3,2)")]
    public decimal AverageRating { get; set; }

    [Column("total_reviews")]
    public int TotalReviews { get; set; }

    [Column("approval_status")]
    [MaxLength(20)]
    public string ApprovalStatus { get; set; } = "Pending";

    [Column("account_status")]
    [MaxLength(20)]
    public string AccountStatus { get; set; } = "Active";

    [Column("subscription_start_date", TypeName = "date")]
    public DateTime? SubscriptionStartDate { get; set; }

    [Column("subscription_end_date", TypeName = "date")]
    public DateTime? SubscriptionEndDate { get; set; }

    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }

    public Admin? Admin { get; set; }

    public ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();

    public ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    public ICollection<AvailabilitySchedule> AvailabilitySchedules { get; set; } = new List<AvailabilitySchedule>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();

    [NotMapped]
    public int Id => ProviderId;

    public string GetAuthPassword()
    {
        return PasswordHash;
    }

    public bool IsApproved()
    {
        return ApprovalStatus == "Approved";
    }

    [NotMapped]
    public int ProviderServicesCount { get; set; }
}
