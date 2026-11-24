using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Auth;
using Wijha.Support.Hashing;
using Wijha.Support.Http;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class PasswordRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "current_password")]
    [RequiredRule]
    [StringRule]
    public string? CurrentPassword { get; set; }

    [FromForm(Name = "password")]
    [RequiredRule]
    [ConfirmedRule]
    [DifferentRule("current_password")]
    [PasswordRule(8, letters: true, mixedCase: true, numbers: true, symbols: true)]
    public string? Password { get; set; }

    [FromForm(Name = "password_confirmation")]
    public string? PasswordConfirmation { get; set; }

    public override bool Authorize()
    {
        return Support.Auth.Auth.Guard(HttpContext, Support.Auth.Auth.Admin).Check();
    }

    public override void WithValidator(Validator validator)
    {
        var admin = Support.Auth.Auth.Guard(HttpContext, Support.Auth.Auth.Admin).User<Models.Admin>()!;
        if (!Hash.Check(CurrentPassword ?? string.Empty, admin.PasswordHash))
        {
            validator.Add("current_password", "Your current password is incorrect.");
        }
    }

    public override Dictionary<string, string> Attributes()
    {
        var labels = new Dictionary<string, string>
        {
            ["current_password"] = "Current Password",
            ["password"] = "New Password",
        };

        foreach (var pair in base.Attributes())
        {
            labels.TryAdd(pair.Key, pair.Value);
        }

        return labels;
    }

    public override Dictionary<string, string> Messages()
    {
        return new Dictionary<string, string>
        {
            ["password.different"] = "Choose a password different from your current one.",
        };
    }
}
