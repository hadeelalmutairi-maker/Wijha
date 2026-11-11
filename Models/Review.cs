using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("reviews")]
public class Review
{
    public static readonly string[] Fillable =
    {
        "booking_id", "moderated_by_admin_id", "rating", "review_text", "is_visible",
    };

    [Key]
    [Column("review_id")]
    public int ReviewId { get; set; }

    [Column("booking_id")]
    public int BookingId { get; set; }

    [Column("moderated_by_admin_id")]
    public int? ModeratedByAdminId { get; set; }

    [Column("rating")]
    public byte Rating { get; set; }

    [Column("review_text")]
    [MaxLength(1000)]
    public string? ReviewText { get; set; }

    [Column("review_date")]
    public DateTime ReviewDate { get; set; }

    [Column("is_visible")]
    public bool IsVisible { get; set; } = true;

    public Booking Booking { get; set; } = null!;

    public Admin? Moderator { get; set; }
}
