using FreeAgent.Model;
using FreeAgent.Helpers;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class InvoiceExtensions
    {
        public static async Task<List<Invoice>> GetInvoicesAsync(this FreeAgentClient client, InvoiceViewFilter invoiceFilter = null, InvoiceOrder orderBy = InvoiceOrder.CreatedAt)
        {
            var filter = invoiceFilter ?? InvoiceViewFilter.RecentOpenOrOverdue();
            var order = orderBy.GetMemberValue();

            var result = await client.Execute(c => c.InvoiceList(client.Configuration.CurrentHeader, filter.FilterValue, order));
            return result.Invoices;
        }

        public static async Task<Invoice> CreateInvoice(this FreeAgentClient client, Invoice invoice)
        {
            var result = await client.Execute(c => c.CreateInvoice(client.Configuration.CurrentHeader, invoice));
            return result.Invoice;
        }

        public static async Task<bool> ChangeInvoiceStatus(this FreeAgentClient client, Invoice invoice, InvoiceStatus newStatus)
        {
            var id = client.ExtractId(invoice);
            var newValue = "mark_as_" + newStatus.GetMemberValue().ToLowerInvariant();

            await client.Execute(c => c.ChangeInvoiceStatus(client.Configuration.CurrentHeader, id, newValue));
            return true;
        }
    }

    // TODO - revise this
    public class InvoiceViewFilter
    {
        internal string FilterValue { get; set; }

        public static InvoiceViewFilter RecentOpenOrOverdue()
        {
            return new InvoiceViewFilter { FilterValue = "recent_open_or_overdue" };
        }

        public static string OpenOrOverdue = "open_or_overdue";
        public static string Draft = "draft";
        public static string ScheduledToEmail = "scheduled_to_email";
        public static string ThankYouEmails = "thank_you_emails";
        public static string ReminderEmails = "reminder_emails";
        private static string lastNMonths = "last_{0}_months";

        public static string LastNMonths(int months = 1)
        {
            return string.Format(lastNMonths, months);
        }
    }

    public enum InvoiceOrder
    {
        [EnumMember(Value = "created_at")] CreatedAt,
        [EnumMember(Value = "-created_at")] CreatedAtDescending,
        [EnumMember(Value = "updated_at")] UpdatedAt,
        [EnumMember(Value = "-updated_at")] UpdatedAtDescending,
        [EnumMember(Value = "dated_on")] DatedOn,
        [EnumMember(Value = "-dated_on")] DatedOnDescending,
        [EnumMember(Value = "due_date")] DueDate, 
        [EnumMember(Value = "-due_date")] DueDateDescending, 
        [EnumMember(Value = "reference")] Reference,
        [EnumMember(Value = "-reference")] ReferenceDescending,
        [EnumMember(Value = "total_value")] TotalValue,
        [EnumMember(Value = "-total_value")] TotalValueDescending,
        [EnumMember(Value = "short_status")] ShortStatus, 
        [EnumMember(Value = "-short_status")] ShortStatusDescending, 
        [EnumMember(Value = "contact_and_project_name")] ContactAndProject,
        [EnumMember(Value = "-contact_and_project_name")] ContactAndProjectDescending
    }
}
