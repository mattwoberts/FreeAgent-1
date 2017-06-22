using FreeAgent.Model;
using FreeAgent.Helpers;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System;

namespace FreeAgent
{
    public static class InvoiceExtensions
    {
        public static Task<IEnumerable<Invoice>> GetInvoicesAsync(this FreeAgentClient client, InvoiceViewFilter invoiceFilter = null, InvoiceOrder orderBy = InvoiceOrder.CreatedAt)
        {
            var view = invoiceFilter ?? InvoiceViewFilter.RecentOpenOrOverdue();
            var sort = orderBy.GetMemberValue();

            return client.GetOrCreateAsync(c => c.InvoiceList(client.Configuration.CurrentHeader, view.FilterValue, sort), r => r.Invoices); 
        }

        public static Task<Invoice> CreateInvoice(this FreeAgentClient client, Invoice invoice)
        {
            return client.GetOrCreateAsync(c => c.CreateInvoice(client.Configuration.CurrentHeader, invoice.Wrap()), r => r.Invoice); 
        }

        public static Task CreateInvoiceEmail(this FreeAgentClient client, int invoiceId, InvoiceEmail email)
        {
            return client.Execute(c => c.EmailInvoice(client.Configuration.CurrentHeader, invoiceId, email.Wrap()));
        }

        public static Task<Invoice> GetInvoiceAsync(this FreeAgentClient client, Invoice invoice)
        {
            var id = client.ExtractId(invoice);
            return client.GetInvoiceAsync(id);
        }

        public static Task<Invoice> GetInvoiceAsync(this FreeAgentClient client, Uri url)
        {
            var id = url.GetId();
            return client.GetInvoiceAsync(id);
        }

        public static Task<Invoice> GetInvoiceAsync(this FreeAgentClient client, int invoiceId)
        {
            return client.GetOrCreateAsync(c => c.GetInvoice(client.Configuration.CurrentHeader, invoiceId), r => r.Invoice);
        }

        public static Task<InvoicePdf> GetInvoicePdfAsync(this FreeAgentClient client, int invoiceId)
        {
            return client.GetOrCreateAsync(c => c.GetInvoicePdf(client.Configuration.CurrentHeader, invoiceId), r => r.Pdf);
        }

        public static Task ChangeInvoiceStatus(this FreeAgentClient client, Invoice invoice, InvoiceStatus newStatus)
        {
            var newValue = "mark_as_" + newStatus.GetMemberValue().ToLowerInvariant();
            return client.UpdateOrDeleteAsync(invoice, (c, id) => c.ChangeInvoiceStatus(client.Configuration.CurrentHeader, id, newValue));
        }

        internal static InvoiceWrapper Wrap(this Invoice invoice)
        {
            return new InvoiceWrapper { Invoice = invoice };
        }

        internal static InvoiceEmailWrapper Wrap(this InvoiceEmail email)
        {
            return new InvoiceEmailWrapper { Invoice = email};
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
