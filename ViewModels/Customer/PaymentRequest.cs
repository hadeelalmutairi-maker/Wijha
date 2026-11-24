using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Wijha.Support.Http;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Customer;

public class PaymentRequest : HasWijhaAttributeLabels
{
    public static readonly string[] METHODS = { "Credit Card", "Apple Pay" };

    public static readonly string[] CARD_METHODS = { "Credit Card" };

    [FromForm(Name = "payment_method")]
    [RequiredRule]
    [InRule("Credit Card", "Apple Pay")]
    public string? PaymentMethod { get; set; }

    [FromForm(Name = "card_name")]
    [ExcludeUnless("payment_method", "Credit Card")]
    [RequiredIfRule("payment_method", "Credit Card")]
    [StringRule]
    [MaxRule(100)]
    public string? CardName { get; set; }

    [FromForm(Name = "card_number")]
    [ExcludeUnless("payment_method", "Credit Card")]
    [RequiredIfRule("payment_method", "Credit Card")]
    [DigitsRule(16)]
    public string? CardNumber { get; set; }

    [FromForm(Name = "card_exp")]
    [ExcludeUnless("payment_method", "Credit Card")]
    [RequiredIfRule("payment_method", "Credit Card")]
    [RegexRule(@"^(0[1-9]|1[0-2])\/\d{2}$")]
    public string? CardExp { get; set; }

    [FromForm(Name = "card_cvv")]
    [ExcludeUnless("payment_method", "Credit Card")]
    [RequiredIfRule("payment_method", "Credit Card")]
    [DigitsRule(3)]
    public string? CardCvv { get; set; }

    public override bool Authorize()
    {
        return true;
    }

    public override void PrepareForValidation()
    {
        if (!CARD_METHODS.Contains(PaymentMethod))
        {
            return;
        }

        CardNumber = Regex.Replace(CardNumber ?? string.Empty, @"\D", string.Empty);
        CardExp = Regex.Replace(CardExp ?? string.Empty, @"\s+", string.Empty);
        CardCvv = (CardCvv ?? string.Empty).Trim();
        CardName = (CardName ?? string.Empty).Trim();
    }

    public override void WithValidator(Validator validator)
    {
        if (!CARD_METHODS.Contains(PaymentMethod) || string.IsNullOrEmpty(CardExp)
            || !Regex.IsMatch(CardExp, @"^(0[1-9]|1[0-2])\/\d{2}$"))
        {
            return;
        }

        var month = DateTime.ParseExact(CardExp, "MM/yy", CultureInfo.InvariantCulture);
        var endOfMonth = new DateTime(month.Year, month.Month, DateTime.DaysInMonth(month.Year, month.Month), 23, 59, 59);

        if (endOfMonth < DateTime.Now)
        {
            validator.Add("card_exp", "This card has expired.");
        }
    }

    public override Dictionary<string, string> Messages()
    {
        return new Dictionary<string, string>
        {
            ["payment_method.in"] = "Choose Credit Card or Apple Pay.",
            ["card_name.required_if"] = "Enter the name on the card.",
            ["card_number.required_if"] = "Enter your card number.",
            ["card_number.digits"] = "The card number must be 16 digits.",
            ["card_exp.required_if"] = "Enter the expiry date.",
            ["card_exp.regex"] = "Use the format MM / YY.",
            ["card_cvv.required_if"] = "Enter the 3-digit CVV.",
            ["card_cvv.digits"] = "The CVV must be 3 digits.",
        };
    }
}
