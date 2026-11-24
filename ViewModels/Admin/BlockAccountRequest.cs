using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class BlockAccountRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "reason")]
    [RequiredRule]
    [StringRule]
    [MaxRule(500)]
    public string? Reason { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
