using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("messages")]
public class Message
{
    public static readonly string[] Fillable =
    {
        "customer_id", "provider_id", "booking_id", "sender_type", "message_text",
        "attachment_url", "is_read",
    };

    [Key]
    [Column("message_id")]
    public int MessageId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("provider_id")]
    public int ProviderId { get; set; }

    [Column("booking_id")]
    public int? BookingId { get; set; }

    [Column("sender_type")]
    [MaxLength(20)]
    public string SenderType { get; set; } = string.Empty;

    [Column("message_text")]
    [MaxLength(1000)]
    public string MessageText { get; set; } = string.Empty;

    [Column("attachment_url")]
    [MaxLength(255)]
    public string? AttachmentUrl { get; set; }

    [Column("sent_at")]
    public DateTime SentAt { get; set; }

    [Column("is_read")]
    public bool IsRead { get; set; }

    public Customer Customer { get; set; } = null!;

    public ServiceProvider ServiceProvider { get; set; } = null!;

    public Booking? Booking { get; set; }

    [NotMapped]
    public int UnreadCount { get; set; }
}
