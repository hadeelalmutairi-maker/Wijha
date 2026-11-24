using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Auth;

public class ResetPasswordRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "password")]
    [RequiredRule]
    [ConfirmedRule]
    [PasswordRule(8, letters: true, mixedCase: true, numbers: true, symbols: true)]
    public string? Password { get; set; }

    [FromForm(Name = "password_confirmation")]
    public string? PasswordConfirmation { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
