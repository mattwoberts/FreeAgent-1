using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum RecurringInvoiceStatus
	{
        [EnumMember(Value = "Draft")] Draft,
		[EnumMember(Value = "Active")] Active,
		[EnumMember(Value = "InActive")] InActive
	}
}