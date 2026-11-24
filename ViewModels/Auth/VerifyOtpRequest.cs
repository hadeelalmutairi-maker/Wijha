using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Auth;

public class VerifyOtpRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "email")]
    [RequiredRule]
    [EmailRule]
    public string? Email { get; set; }

    [FromForm(Name = "otp")]
    [RequiredRule]
    [DigitsRule(6)]
    public string? Otp { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
