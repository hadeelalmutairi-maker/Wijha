using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Customer;

public class BookingRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "provider_service_id")]
    [RequiredRule]
    [IntegerRule]
    [ExistsRule("provider_services", "provider_service_id")]
    public int? ProviderServiceId { get; set; }

    [FromForm(Name = "my_event_id")]
    [IntegerRule]
    [ExistsRule("my_events", "my_event_id", WhereColumn = "customer_id", WhereGuardId = "customer")]
    public int? MyEventId { get; set; }

    [FromForm(Name = "service_date")]
    [RequiredRule]
    [DateRule]
    [AfterRule("today")]
    public string? ServiceDate { get; set; }

    [FromForm(Name = "service_time")]
    [RequiredRule]
    [DateFormatRule("H:i")]
    public string? ServiceTime { get; set; }

    [FromForm(Name = "venue_address")]
    [RequiredRule]
    [StringRule]
    [MaxRule(255)]
    public string? VenueAddress { get; set; }

    [FromForm(Name = "guest_count")]
    [IntegerRule]
    [MinRule(0)]
    public int? GuestCount { get; set; }

    [FromForm(Name = "quantity")]
    [RequiredRule]
    [IntegerRule]
    [MinRule(1)]
    public int? Quantity { get; set; }

    [FromForm(Name = "special_requirements")]
    [StringRule]
    [MaxRule(1000)]
    public string? SpecialRequirements { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
