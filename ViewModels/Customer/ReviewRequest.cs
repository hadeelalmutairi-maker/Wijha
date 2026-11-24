using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Customer;

public class ReviewRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "rating")]
    [RequiredRule]
    [IntegerRule]
    [MinRule(1)]
    [MaxRule(5)]
    public int? Rating { get; set; }

    [FromForm(Name = "review_text")]
    [StringRule]
    [MaxRule(1000)]
    public string? ReviewText { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
