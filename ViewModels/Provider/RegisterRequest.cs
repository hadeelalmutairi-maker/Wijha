using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Rules;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Provider;

public class RegisterRequest : HasWijhaAttributeLabels
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
    [UniqueRule("service_providers", "email")]
    public string? Email { get; set; }

    [FromForm(Name = "phone")]
    [RequiredRule]
    [WijhaSaudiPhone]
    [UniqueRule("service_providers", "phone")]
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

    [FromForm(Name = "commercial_register_no")]
    [RequiredRule]
    [DigitsRule(10)]
    [UniqueRule("service_providers", "commercial_register_no")]
    public string? CommercialRegisterNo { get; set; }

    [FromForm(Name = "business_description")]
    [StringRule]
    [MaxRule(1000)]
    public string? BusinessDescription { get; set; }

    [FromForm(Name = "logo")]
    [ImageRule]
    [MimesRule("jpg", "jpeg", "png")]
    [MaxRule(2048)]
    public IFormFile? Logo { get; set; }

    [FromForm(Name = "password")]
    [RequiredRule]
    [ConfirmedRule]
    [PasswordRule(8, letters: true, mixedCase: true, numbers: true, symbols: true)]
    public string? Password { get; set; }

    [FromForm(Name = "password_confirmation")]
    public string? PasswordConfirmation { get; set; }

    [FromForm(Name = "terms")]
    [AcceptedRule]
    public string? Terms { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
