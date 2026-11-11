using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Wijha.Models;

[Table("admins")]
public class Admin : IAuthenticatable
{
    public static readonly string[] Fillable =
    {
        "full_name", "email", "password_hash", "phone", "admin_role", "last_login",
    };

    [Key]
    [Column("admin_id")]
    public int AdminId { get; set; }

    [Column("full_name")]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

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

    [Column("admin_role")]
    [MaxLength(20)]
    public string AdminRole { get; set; } = "Support Admin";

    [Column("last_login")]
    public DateTime? LastLogin { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public ICollection<ServiceProvider> ServiceProviders { get; set; } = new List<ServiceProvider>();

    public ICollection<Review> ModeratedReviews { get; set; } = new List<Review>();

    [NotMapped]
    public int Id => AdminId;

    public string GetAuthPassword()
    {
        return PasswordHash;
    }
}
