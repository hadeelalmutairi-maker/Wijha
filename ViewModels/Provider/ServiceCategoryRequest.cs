using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Provider;

public class ServiceCategoryRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "category_name")]
    [RequiredRule]
    [StringRule]
    [MaxRule(100)]
    public string? CategoryName { get; set; }

    [FromForm(Name = "category_description")]
    [StringRule]
    [MaxRule(500)]
    public string? CategoryDescription { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
