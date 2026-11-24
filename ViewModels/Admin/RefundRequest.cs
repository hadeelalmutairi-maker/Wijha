using Microsoft.AspNetCore.Mvc;
using Wijha.Data;
using Wijha.Support.Http;
using Wijha.Support.Validation;
using Wijha.ViewModels.Concerns;

namespace Wijha.ViewModels.Admin;

public class RefundRequest : HasWijhaAttributeLabels
{
    [FromForm(Name = "refund_amount")]
    [RequiredRule]
    [NumericRule]
    [MinRule(0.01)]
    public decimal? RefundAmount { get; set; }

    public override bool Authorize()
    {
        return true;
    }

    public override void WithValidator(Validator validator)
    {
        var db = validator.Service<AppDbContext>();
        var payment = int.TryParse(Route("payment")?.ToString(), out var paymentId) ? db.Payments.Find(paymentId) : null;

        if (payment != null && RefundAmount > payment.Amount)
        {
            validator.Add("refund_amount", "The refund amount cannot exceed the original paid amount (SAR " + payment.Amount.ToString("N2") + ").");
        }
    }
}
