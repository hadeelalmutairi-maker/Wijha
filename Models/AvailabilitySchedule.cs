using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("availability_schedules")]
public class AvailabilitySchedule
{
    public static readonly string[] Fillable =
    {
        "provider_id", "available_date", "start_time", "end_time", "availability_status",
    };

    [Key]
    [Column("availability_id")]
    public int AvailabilityId { get; set; }

    [Column("provider_id")]
    public int ProviderId { get; set; }

    [Column("available_date", TypeName = "date")]
    public DateTime AvailableDate { get; set; }

    [Column("start_time", TypeName = "time(0)")]
    public TimeSpan StartTime { get; set; }

    [Column("end_time", TypeName = "time(0)")]
    public TimeSpan EndTime { get; set; }

    [Column("availability_status")]
    [MaxLength(20)]
    public string AvailabilityStatus { get; set; } = "Open";

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public ServiceProvider ServiceProvider { get; set; } = null!;
}
