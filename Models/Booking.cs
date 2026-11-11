using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("bookings")]
public class Booking
{
    public static readonly string[] Fillable =
    {
        "customer_id", "my_event_id", "provider_service_id", "service_date", "service_time",
        "venue_address", "guest_count", "quantity", "agreed_price", "special_requirements",
        "booking_status", "modification_deadline", "provider_response_date",
        "rejection_reason", "cancellation_date", "cancellation_reason",
    };

    [Key]
    [Column("booking_id")]
    public int BookingId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("my_event_id")]
    public int? MyEventId { get; set; }

    [Column("provider_service_id")]
    public int ProviderServiceId { get; set; }

    [Column("booking_date")]
    public DateTime BookingDate { get; set; }

    [Column("service_date", TypeName = "date")]
    public DateTime ServiceDate { get; set; }

    [Column("service_time", TypeName = "time(0)")]
    public TimeSpan ServiceTime { get; set; }

    [Column("venue_address")]
    [MaxLength(255)]
    public string VenueAddress { get; set; } = string.Empty;

    [Column("guest_count")]
    public int? GuestCount { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; } = 1;

    [Column("agreed_price", TypeName = "decimal(10,2)")]
    public decimal AgreedPrice { get; set; }

    [Column("special_requirements")]
    [MaxLength(1000)]
    public string? SpecialRequirements { get; set; }

    [Column("booking_status")]
    [MaxLength(20)]
    public string BookingStatus { get; set; } = "Pending";

    [Column("modification_deadline")]
    public DateTime? ModificationDeadline { get; set; }

    [Column("provider_response_date")]
    public DateTime? ProviderResponseDate { get; set; }

    [Column("rejection_reason")]
    [MaxLength(500)]
    public string? RejectionReason { get; set; }

    [Column("cancellation_date")]
    public DateTime? CancellationDate { get; set; }

    [Column("cancellation_reason")]
    [MaxLength(500)]
    public string? CancellationReason { get; set; }

    public Customer Customer { get; set; } = null!;

    public MyEvent? MyEvent { get; set; }

    public ProviderService ProviderService { get; set; } = null!;

    public Payment? Payment { get; set; }

    public Review? Review { get; set; }

    public ICollection<Message> Messages { get; set; } = new List<Message>();

    public bool IsEditable()
    {
        return ModificationDeadline != null && DateTime.Now <= ModificationDeadline.Value;
    }

    [NotMapped]
    public string Reference
    {
        get
        {
            var year = BookingDate == default ? DateTime.Now.Year : BookingDate.Year;

            return "WJ-" + year + "-" + BookingId.ToString().PadLeft(4, '0');
        }
    }

    public (string Label, string Badge) PaymentState()
    {
        if (Payment != null)
        {
            return Payment.PaymentStatus switch
            {
                "Paid" => ("Paid", "b-ok"),
                "Refunded" => ("Refunded", "b-warn"),
                "Failed" => ("Failed", "b-err"),
                _ => (Payment.PaymentStatus, "b-warn"),
            };
        }

        return BookingStatus switch
        {
            "Pending" => ("Not due yet", "b-grey"),
            "Accepted" => ("Awaiting payment", "b-warn"),
            _ => ("Not charged", "b-grey"),
        };
    }
}
