using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class ProviderDecisionRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "decision")]
    [RequiredRule]
    [InRule("approve", "reject")]
    public string? Decision { get; set; }

    [FromForm(Name = "reason")]
    [RequiredIfRule("decision", "reject")]
    [StringRule]
    [MaxRule(500)]
    public string? Reason { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
