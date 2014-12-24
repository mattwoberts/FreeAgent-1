using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum InvoiceItemType
	{
		[EnumMember(Value = "Hours")] Hours,
		[EnumMember(Value = "Days")] Days,
		[EnumMember(Value = "Weeks")] Weeks,
		[EnumMember(Value = "Months")] Months,
		[EnumMember(Value = "Years")]  Years,
		[EnumMember(Value = "Products")] Products,
		[EnumMember(Value = "Services")] Services,
		[EnumMember(Value = "Training")] Training,
		[EnumMember(Value = "Expenses")] Expenses,
		[EnumMember(Value = "Comment")]  Comment,
		[EnumMember(Value = "Bills")]  Bills,
		[EnumMember(Value = "Discount")] Discount,
		[EnumMember(Value = "Credit")] Credit,
		[EnumMember(Value = "VAT")] VAT,
		[EnumMember(Value = "No Unit")] NoUnit
	}
}




