using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    /// <summary>
    /// Taken from FreeAgent's docs: https://dev.freeagent.com/docs/invoices#mark-invoice-as-sent
    /// </summary>
	public enum InvoiceStatus
	{
        [EnumMember(Value = "Draft")] Draft,
		[EnumMember(Value = "Scheduled To Email")] ScheduledToEmail,
	    [EnumMember(Value = "Open")] Open,
        [EnumMember(Value = "Zero Value")] ZeroValue,
        [EnumMember(Value = "Overdue")] Overdue,
        [EnumMember(Value = "Paid")] Paid,
        [EnumMember(Value = "Overpaid")] Overpaid,
        [EnumMember(Value = "Refunded")] Refunded,
        [EnumMember(Value = "Written-off")] WrittenOff,
        [EnumMember(Value = "Part written-off")] PartWrittenOff,

    }

    public enum MarkInvoiceSetting
    {
        [EnumMember(Value = "Draft")] Draft,
        [EnumMember(Value = "Scheduled")] Scheduled,
        [EnumMember(Value = "Sent")] Sent,
        [EnumMember(Value = "Cancelled")] Cancelled,

    }
}