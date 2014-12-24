using FreeAgent.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class InvoiceExtensions
    {
        public static async Task<List<Invoice>> GetInvoicesAsync(this FreeAgentClient client, InvoiceViewFilter invoiceFilter = null)
        {
            var filter = invoiceFilter ?? InvoiceViewFilter.RecentOpenOrOverdue();
            var result = await client.Execute(c =>
            {
                return c.GetInvoiceList(client.Configuration.CurrentHeader, filter.FilterValue);
            });

            return result.Invoices;
        }

        public static async Task<Invoice> CreateInvoice(this FreeAgentClient client, Invoice invoice)
        {
            var result = await client.Execute(c =>
            {
                return c.PostInvoice(client.Configuration.CurrentHeader, invoice);
            });

            return result.Invoice;
        }

        public static async Task<bool> SendInvoice(this FreeAgentClient client, Invoice invoice)
        {
            var id = client.ExtractId(invoice);

            await client.Execute(c =>
            {
                return c.PutInvoiceStatus(client.Configuration.CurrentHeader, id, "mark_as_sent");
            });

            return true;
        }

        public static async Task<bool> CancelInvoice(this FreeAgentClient client, Invoice invoice)
        {
            var id = client.ExtractId(invoice);

            await client.Execute(c =>
            {
                return c.PutInvoiceStatus(client.Configuration.CurrentHeader, id, "mark_as_cancelled");
            });

            return true;
        }

        public static async Task<bool> ScheduleInvoice(this FreeAgentClient client, Invoice invoice)
        {
            var id = client.ExtractId(invoice);

            await client.Execute(c =>
            {
                return c.PutInvoiceStatus(client.Configuration.CurrentHeader, id, "mark_as_scheduled");
            });

            return true;
        }

        public static async Task<bool> MakeDraftInvoice(this FreeAgentClient client, Invoice invoice)
        {
            var id = client.ExtractId(invoice);

            await client.Execute(c =>
            {
                return c.PutInvoiceStatus(client.Configuration.CurrentHeader, id, "mark_as_draft");
            });

            return true;
        }
    }

    // TODO - revise this
    public class InvoiceViewFilter
    {
        internal string FilterValue { get; set; }
        internal string SortValue { get; set; }

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

    public static class InvoiceViewFilterOrdering
    {
        public static InvoiceViewFilter OrderByCreated(this InvoiceViewFilter filter)
        {
            filter.SortValue = "created_at";
            return filter;
        }

        public static InvoiceViewFilter OrderByUpdated(this InvoiceViewFilter filter)
        {
            filter.SortValue = "updated_at";
            return filter;
        }
    }

    //TODO - replace the various status changes with an enum that we get the member value from...
    public enum ChangeInvoiceStatus
    {
        [EnumMember(Value = "mark_as_draft")] Draft,
        [EnumMember(Value = "mark_as_scheduled")] Scheduled,
        [EnumMember(Value = "mark_as_sent")] Sent,
        [EnumMember(Value = "mark_as_cancelled")] Cancelled
    }
}
