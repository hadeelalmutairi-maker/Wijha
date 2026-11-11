using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Wijha.Models;

[Table("customers")]
public class Customer : IAuthenticatable
{
    public static readonly string[] Fillable =
    {
        "first_name", "last_name", "email", "password_hash", "phone", "gender",
        "city", "profile_image_url", "account_status", "last_login",
    };

    [Key]
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("first_name")]
    [MaxLength(60)]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    [MaxLength(60)]
    public string LastName { get; set; } = string.Empty;

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

    [Column("gender")]
    [MaxLength(10)]
    public string? Gender { get; set; }

    [Column("city")]
    [MaxLength(60)]
    public string City { get; set; } = string.Empty;

    [Column("profile_image_url")]
    [MaxLength(255)]
    public string? ProfileImageUrl { get; set; }

    [Column("account_status")]
    [MaxLength(20)]
    public string AccountStatus { get; set; } = "Active";

    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }

    [Column("last_login")]
    public DateTime? LastLogin { get; set; }

    public ICollection<MyEvent> MyEvents { get; set; } = new List<MyEvent>();

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();

    [NotMapped]
    public int Id => CustomerId;

    public string GetAuthPassword()
    {
        return PasswordHash;
    }

    [NotMapped]
    public int BookingsCount { get; set; }
}
