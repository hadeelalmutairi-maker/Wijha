using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("my_events")]
public class MyEvent
{
    public static readonly string[] Fillable =
    {
        "customer_id", "event_name", "event_type", "event_date", "total_budget", "event_status",
    };

    [Key]
    [Column("my_event_id")]
    public int MyEventId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("event_name")]
    [MaxLength(150)]
    public string EventName { get; set; } = string.Empty;

    [Column("event_type")]
    [MaxLength(50)]
    public string EventType { get; set; } = string.Empty;

    [Column("event_date", TypeName = "date")]
    public DateTime EventDate { get; set; }

    [Column("total_budget", TypeName = "decimal(10,2)")]
    public decimal? TotalBudget { get; set; }

    [Column("event_status")]
    [MaxLength(20)]
    public string EventStatus { get; set; } = "Planning";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public Customer Customer { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [NotMapped]
    public int BookingsCount { get; set; }
}
