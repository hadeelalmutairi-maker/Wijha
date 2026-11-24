using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Hashing;
using Wijha.Support.Http;
using Wijha.Support.Rules;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class ProfileRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "full_name")]
    [RequiredRule]
    [StringRule]
    [MinRule(3)]
    [MaxRule(100)]
    public string? FullName { get; set; }

    [FromForm(Name = "email")]
    [RequiredRule]
    [EmailRule]
    [MaxRule(150)]
    [UniqueRule("admins", "email", IgnoreGuard = "admin", IdColumn = "admin_id")]
    public string? Email { get; set; }

    [FromForm(Name = "phone")]
    [WijhaSaudiPhone]
    public string? Phone { get; set; }

    [FromForm(Name = "email_password")]
    [StringRule]
    public string? EmailPassword { get; set; }

    public override bool Authorize()
    {
        return Support.Auth.Auth.Guard(HttpContext, Support.Auth.Auth.Admin).Check();
    }

    public override void WithValidator(Validator validator)
    {
        var admin = Support.Auth.Auth.Guard(HttpContext, Support.Auth.Auth.Admin).User<Models.Admin>()!;
        if (!string.Equals(Email ?? string.Empty, admin.Email, StringComparison.OrdinalIgnoreCase)
            && !Hash.Check(EmailPassword ?? string.Empty, admin.PasswordHash))
        {
            validator.Add("email_password", "Enter your current password to change your email.");
        }
    }

    public override Dictionary<string, string> Attributes()
    {
        var labels = new Dictionary<string, string>
        {
            ["full_name"] = "Full Name",
            ["email_password"] = "Current Password",
        };

        foreach (var pair in base.Attributes())
        {
            labels.TryAdd(pair.Key, pair.Value);
        }

        return labels;
    }
}
