using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Auth;

public class ForgotPasswordRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "email")]
    [RequiredRule]
    [EmailRule]
    public string? Email { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
