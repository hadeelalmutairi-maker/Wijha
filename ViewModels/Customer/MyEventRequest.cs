using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Customer;

public class MyEventRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "event_name")]
    [RequiredRule]
    [StringRule]
    [MaxRule(150)]
    public string? EventName { get; set; }

    [FromForm(Name = "event_type")]
    [RequiredRule]
    [InRule("Wedding", "Engagement", "Graduation", "Birthday", "Baby Shower", "Corporate", "National Day", "Other")]
    public string? EventType { get; set; }

    [FromForm(Name = "event_date")]
    [RequiredRule]
    [DateRule]
    [AfterRule("today")]
    public string? EventDate { get; set; }

    [FromForm(Name = "total_budget")]
    [NumericRule]
    [MinRule(0)]
    public decimal? TotalBudget { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
