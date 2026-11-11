using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wijha.Models;

[Table("failed_jobs")]
public class FailedJob
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("uuid")]
    [MaxLength(255)]
    public string Uuid { get; set; } = string.Empty;

    [Column("connection")]
    public string Connection { get; set; } = string.Empty;

    [Column("queue")]
    public string Queue { get; set; } = string.Empty;

    [Column("payload")]
    public string Payload { get; set; } = string.Empty;

    [Column("exception")]
    public string Exception { get; set; } = string.Empty;

    [Column("failed_at")]
    public DateTime FailedAt { get; set; }
}
