using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Provider;

public class ProviderServiceRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "service_id")]
    [RequiredRule]
    [IntegerRule]
    [ExistsRule("services", "service_id")]
    public int? ServiceId { get; set; }

    [FromForm(Name = "service_category_id")]
    [IntegerRule]
    [ExistsRule("service_categories", "service_category_id")]
    public int? ServiceCategoryId { get; set; }

    [FromForm(Name = "offering_title")]
    [RequiredRule]
    [StringRule]
    [MaxRule(150)]
    public string? OfferingTitle { get; set; }

    [FromForm(Name = "offering_description")]
    [StringRule]
    [MaxRule(1000)]
    public string? OfferingDescription { get; set; }

    [FromForm(Name = "price")]
    [RequiredRule]
    [NumericRule]
    [MinRule(0)]
    public decimal? Price { get; set; }

    [FromForm(Name = "price_unit")]
    [RequiredRule]
    [InRule("Fixed", "Per Hour", "Per Guest", "Per Item")]
    public string? PriceUnit { get; set; }

    [FromForm(Name = "duration_hours")]
    [NumericRule]
    [MinRule(0)]
    public decimal? DurationHours { get; set; }

    [FromForm(Name = "portfolio")]
    [FileRule]
    [MimesRule("jpg", "jpeg", "png", "pdf")]
    [MaxRule(5120)]
    public IFormFile? Portfolio { get; set; }

    [FromForm(Name = "service_city")]
    [RequiredRule]
    [StringRule]
    [MaxRule(60)]
    public string? ServiceCity { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
