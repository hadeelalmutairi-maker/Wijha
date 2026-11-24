using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class BookingStatusRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "booking_status")]
    [RequiredRule]
    [InRule("Pending", "Accepted", "Rejected", "Completed", "Cancelled")]
    public string? BookingStatus { get; set; }

    [FromForm(Name = "reason")]
    [StringRule]
    [MaxRule(500)]
    public string? Reason { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
