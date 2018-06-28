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
		[EnumMember(Value = "Part written-off")] PartWrittenOff, 
		[EnumMember(Value = "Written-off")] WrittenOff, 
		[EnumMember(Value = "Refunded")] Refunded, 
		[EnumMember(Value = "Overdue")] Overdue, 
		[EnumMember(Value = "Zero Value")] ZeroValue, 
		[EnumMember(Value = "Scheduled To Email")] ScheduledToEmail, 
	}
}