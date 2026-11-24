using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class ServiceRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "service_name")]
    [RequiredRule]
    [StringRule]
    [MaxRule(100)]
    [UniqueRule("services", "service_name", IgnoreRouteKey = "service", IdColumn = "service_id")]
    public string? ServiceName { get; set; }

    [FromForm(Name = "service_description")]
    [StringRule]
    [MaxRule(500)]
    public string? ServiceDescription { get; set; }

    [FromForm(Name = "is_active")]
    [BooleanRule]
    public bool? IsActive { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
