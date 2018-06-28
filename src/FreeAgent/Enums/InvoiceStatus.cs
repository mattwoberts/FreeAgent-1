using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum InvoiceStatus
	{
        [EnumMember(Value = "Draft")] Draft,
		[EnumMember(Value = "Scheduled")] Scheduled,
		[EnumMember(Value = "Sent")] Sent,
		[EnumMember(Value = "Cancelled")] Cancelled, 
		[EnumMember(Value = "Open")] Open, 
		[EnumMember(Value = "Paid")] Paid, 
	}
}