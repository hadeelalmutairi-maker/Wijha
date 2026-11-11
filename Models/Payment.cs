using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("payments")]
public class Payment
{
    public static readonly string[] Fillable =
    {
        "booking_id", "invoice_number", "amount", "payment_method", "payment_status",
        "transaction_ref", "payment_date", "refund_amount", "refund_date",
    };

    [Key]
    [Column("payment_id")]
    public int PaymentId { get; set; }

    [Column("booking_id")]
    public int BookingId { get; set; }

    [Column("invoice_number")]
    [MaxLength(30)]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Column("amount", TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    [Column("payment_method")]
    [MaxLength(20)]
    public string PaymentMethod { get; set; } = string.Empty;

    [Column("payment_status")]
    [MaxLength(20)]
    public string PaymentStatus { get; set; } = "Pending";

    [Column("transaction_ref")]
    [MaxLength(50)]
    public string? TransactionRef { get; set; }

    [Column("payment_date")]
    public DateTime? PaymentDate { get; set; }

    [Column("refund_amount", TypeName = "decimal(10,2)")]
    public decimal? RefundAmount { get; set; }

    [Column("refund_date")]
    public DateTime? RefundDate { get; set; }

    public Booking Booking { get; set; } = null!;
}
