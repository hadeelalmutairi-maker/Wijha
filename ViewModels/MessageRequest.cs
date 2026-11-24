using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels;

public class MessageRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "message_text")]
    [RequiredWithoutRule("attachment")]
    [StringRule]
    [MaxRule(1000)]
    public string? MessageText { get; set; }

    [FromForm(Name = "attachment")]
    [FileRule]
    [MimesRule("jpg", "jpeg", "png", "pdf")]
    [MaxRule(5120)]
    public IFormFile? Attachment { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
