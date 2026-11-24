using Wijha.Support.Http;

namespace Wijha.ViewModels.Concerns;

public abstract class HasWijhaAttributeLabels : FormRequest
{
    public override Dictionary<string, string> Attributes()
    {
        return new Dictionary<string, string>
        {
            ["first_name"] = "First Name", ["last_name"] = "Last Name",
            ["email"] = "Email Address", ["phone"] = "Phone Number", ["city"] = "City",
            ["gender"] = "Gender", ["profile_image"] = "Profile Photo",
            ["password"] = "Password", ["password_confirmation"] = "Confirm Password",
            ["business_name"] = "Business Name", ["owner_name"] = "Owner Name",
            ["business_address"] = "Business Address", ["business_description"] = "Business Description",
            ["commercial_register_no"] = "Commercial Register Number", ["logo"] = "Business Logo",
            ["event_name"] = "Event Name", ["event_type"] = "Event Type", ["event_date"] = "Event Date",
            ["total_budget"] = "Total Budget",
            ["provider_service_id"] = "Service",
            ["service_date"] = "Service Date", ["service_time"] = "Service Time",
            ["venue_address"] = "Venue Address", ["guest_count"] = "Number of Guests",
            ["quantity"] = "Quantity", ["special_requirements"] = "Special Requirements",
            ["my_event_id"] = "Event",
            ["offering_title"] = "Service Title", ["offering_description"] = "Service Description",
            ["price"] = "Price", ["price_unit"] = "Price Unit", ["duration_hours"] = "Duration (Hours)",
            ["service_city"] = "Service City", ["service_id"] = "Service Type",
            ["service_category_id"] = "Category", ["portfolio"] = "Portfolio File",
            ["category_name"] = "Category Name", ["category_description"] = "Category Description",
            ["display_order"] = "Display Order",
            ["available_date"] = "Available Date", ["start_time"] = "Start Time", ["end_time"] = "End Time",
            ["availability_status"] = "Status",
            ["rating"] = "Rating", ["review_text"] = "Review",
            ["message_text"] = "Message", ["attachment"] = "Attachment", ["rejection_reason"] = "Rejection Reason",
            ["cancellation_reason"] = "Cancellation Reason", ["payment_method"] = "Payment Method",
            ["action"] = "Decision", ["decision"] = "Decision", ["reason"] = "Reason",
            ["terms"] = "Terms of Use",
            ["card_name"] = "Name on Card", ["card_number"] = "Card Number", ["card_exp"] = "Expiry Date",
            ["card_cvv"] = "CVV",
        };
    }

    public override Dictionary<string, string> Messages()
    {
        return new Dictionary<string, string>
        {
            ["terms.accepted"] = "Please agree to the Terms of Use and the Privacy Policy to continue.",
        };
    }
}
