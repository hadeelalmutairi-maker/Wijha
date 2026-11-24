using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Rules;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Customer;

public class ProfileRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "first_name")]
    [RequiredRule]
    [StringRule]
    [MinRule(2)]
    [MaxRule(60)]
    public string? FirstName { get; set; }

    [FromForm(Name = "last_name")]
    [RequiredRule]
    [StringRule]
    [MinRule(2)]
    [MaxRule(60)]
    public string? LastName { get; set; }

    [FromForm(Name = "email")]
    [RequiredRule]
    [EmailRule(rfc: true, dns: true)]
    [MaxRule(150)]
    [UniqueRule("customers", "email", IgnoreGuard = "customer", IdColumn = "customer_id")]
    public string? Email { get; set; }

    [FromForm(Name = "phone")]
    [RequiredRule]
    [WijhaSaudiPhone]
    [UniqueRule("customers", "phone", IgnoreGuard = "customer", IdColumn = "customer_id")]
    public string? Phone { get; set; }

    [FromForm(Name = "city")]
    [RequiredRule]
    [StringRule]
    [MaxRule(60)]
    public string? City { get; set; }

    [FromForm(Name = "gender")]
    [InRule("Male", "Female")]
    public string? Gender { get; set; }

    [FromForm(Name = "profile_image")]
    [ImageRule]
    [MimesRule("jpg", "jpeg", "png")]
    [MaxRule(2048)]
    public IFormFile? ProfileImage { get; set; }

    public override bool Authorize()
    {
        return true;
    }
}
