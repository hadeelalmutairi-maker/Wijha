using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Auth;

public class LoginRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "email")]
    [RequiredRule]
    [EmailRule]
    public string? Email { get; set; }

    [FromForm(Name = "password")]
    [RequiredRule]
    [StringRule]
    public string? Password { get; set; }

    [FromForm(Name = "remember")]
    public bool Remember { get; set; }

    [FromForm(Name = "as")]
    public string? As { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
