using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Provider;

public class AcceptRejectBookingRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "action")]
    [RequiredRule]
    [InRule("accept", "reject")]
    public string? Action { get; set; }

    [FromForm(Name = "rejection_reason")]
    [RequiredIfRule("action", "reject")]
    [StringRule]
    [MaxRule(500)]
    public string? RejectionReason { get; set; }

    [FromForm(Name = "rejection_reason_other")]
    public string? RejectionReasonOther { get; set; }

    [FromForm(Name = "message_text")]
    [StringRule]
    [MaxRule(1000)]
    public string? MessageText { get; set; }

    public override bool Authorize()
    {
        return true;
    }

    public override void PrepareForValidation()
    {
        if (RejectionReason == "__other")
        {
            var other = (RejectionReasonOther ?? string.Empty).Trim();
            RejectionReason = other == string.Empty ? null : other;
        }
    }
}
