using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Rules;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Provider;

public class ProfileRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "business_name")]
    [RequiredRule]
    [StringRule]
    [MaxRule(150)]
    public string? BusinessName { get; set; }

    [FromForm(Name = "owner_name")]
    [RequiredRule]
    [StringRule]
    [MaxRule(100)]
    public string? OwnerName { get; set; }

    [FromForm(Name = "email")]
    [RequiredRule]
    [EmailRule]
    [MaxRule(150)]
    [UniqueRule("service_providers", "email", IgnoreGuard = "provider", IdColumn = "provider_id")]
    public string? Email { get; set; }

    [FromForm(Name = "phone")]
    [RequiredRule]
    [WijhaSaudiPhone]
    [UniqueRule("service_providers", "phone", IgnoreGuard = "provider", IdColumn = "provider_id")]
    public string? Phone { get; set; }

    [FromForm(Name = "city")]
    [RequiredRule]
    [StringRule]
    [MaxRule(60)]
    public string? City { get; set; }

    [FromForm(Name = "business_address")]
    [RequiredRule]
    [StringRule]
    [MaxRule(255)]
    public string? BusinessAddress { get; set; }

    [FromForm(Name = "business_description")]
    [StringRule]
    [MaxRule(1000)]
    public string? BusinessDescription { get; set; }

    [FromForm(Name = "logo")]
    [ImageRule]
    [MimesRule("jpg", "jpeg", "png")]
    [MaxRule(2048)]
    public IFormFile? Logo { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
