using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Provider;

public class AvailabilityRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "available_date")]
    [RequiredRule]
    [DateRule]
    [AfterRule("today", orEqual: true)]
    public string? AvailableDate { get; set; }

    [FromForm(Name = "start_time")]
    [RequiredRule]
    [DateFormatRule("H:i")]
    public string? StartTime { get; set; }

    [FromForm(Name = "end_time")]
    [RequiredRule]
    [DateFormatRule("H:i")]
    [AfterRule("start_time")]
    public string? EndTime { get; set; }

    [FromForm(Name = "availability_status")]
    [RequiredRule]
    [InRule("Open", "Booked", "Blocked")]
    public string? AvailabilityStatus { get; set; }

    [FromForm(Name = "repeat")]
    [InRule("once", "weekly", "daily")]
    public string? Repeat { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
