using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class RecurringInvoiceExtensions
    {
        public static Task<IEnumerable<RecurringInvoice>> GetRecurringInvoicesAsync(this FreeAgentClient client, RecurringInvoiceFilter filterBy = RecurringInvoiceFilter.All, RecurringInvoiceOrder orderBy = RecurringInvoiceOrder.NextRecursOn)
        {
            var view = filterBy.GetMemberValue();
            var sort = orderBy.GetMemberValue();
            return client.GetOrCreateAsync(c => c.RecurringInvoiceList(client.Configuration.CurrentHeader, view, sort, null), r => r.RecurringInvoices); 
        }

        public static Task<IEnumerable<RecurringInvoice>> GetRecurringInvoicesAsync(this FreeAgentClient client, Contact contact)
        {
            var url = client.ExtractUrl(contact);
            return client.GetOrCreateAsync(c => c.RecurringInvoiceList(client.Configuration.CurrentHeader, null, null, url.OriginalString), r => r.RecurringInvoices);
        }

        public static Task<RecurringInvoice> GetRecurringInvoiceAsync(this FreeAgentClient client, RecurringInvoice recurringInvoice)
        {
            var id = client.ExtractId(recurringInvoice);
            return client.GetRecurringInvoiceAsync(id);
        }

        public static Task<RecurringInvoice> GetRecurringInvoiceAsync(this FreeAgentClient client, Uri url)
        {
            var id = url.GetId();
            return client.GetRecurringInvoiceAsync(id);
        }

        public static Task<RecurringInvoice> GetRecurringInvoiceAsync(this FreeAgentClient client, int recurringInvoiceId)
        {
            return client.GetOrCreateAsync(c => c.GetRecurringInvoice(client.Configuration.CurrentHeader, recurringInvoiceId), r => r.RecurringInvoice);
        }

        internal static RecurringInvoiceWrapper Wrap(this RecurringInvoice invoice)
        {
            return new RecurringInvoiceWrapper { RecurringInvoice = invoice };
        }
    }

    public enum RecurringInvoiceFilter
    {
        [EnumMember(Value = null)] All,
        [EnumMember(Value = "Draft")] Draft,
        [EnumMember(Value = "Active")] Active,
        [EnumMember(Value = "InActive")] InActive
    }

    public enum RecurringInvoiceOrder
    {
        [EnumMember(Value = "created_at")] CreatedAt,  //TODO - test this
        [EnumMember(Value = "-created_at")] CreatedAtDescending,
        [EnumMember(Value = "updated_at")] UpdatedAt,
        [EnumMember(Value = "-updated_at")] UpdatedAtDescending,
        [EnumMember(Value = "profile_id")] ProfileId,
        [EnumMember(Value = "-profile_id")] ProfileIdDescending,
        [EnumMember(Value = "frequency")] Frequency, 
        [EnumMember(Value = "-frequency")] FrequencyDescending, 
        [EnumMember(Value = "next_recurs_on")] NextRecursOn,
        [EnumMember(Value = "-next_recurs_on")] NextRecursOnDescending,
        [EnumMember(Value = "last_recurred_on")] LastRecurredOn,
        [EnumMember(Value = "-last_recurred_on")] LastRecurredOnDescending,
        [EnumMember(Value = "total_value")] TotalValue,
        [EnumMember(Value = "-total_value")] TotalValueDescending,
        [EnumMember(Value = "recurring_end_date")] RecurringEndDate, 
        [EnumMember(Value = "-recurring_end_date")] RecurringEndDateDescending, 
        [EnumMember(Value = "contact_and_project_name")] ContactAndProject,
        [EnumMember(Value = "-contact_and_project_name")] ContactAndProjectDescending
    }
}
