using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class BillExtensions
    {
        public static Task<List<Bill>> GetBillsAsync(this FreeAgentClient client, ContactFilter filterBy = ContactFilter.All, ContactOrder orderBy = ContactOrder.Name, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var view = filterBy.GetMemberValue();
            var sort = orderBy.GetMemberValue();

            return client.GetOrCreateAsync(c => c.BillList(client.Configuration.CurrentHeader, view, sort, fromDate, toDate), r => r.Bills); 
        }

        public static Task<Bill> CreateBillAsync(this FreeAgentClient client, Bill bill)
        {
            return client.GetOrCreateAsync(c => c.CreateBill(client.Configuration.CurrentHeader, bill.Wrap()), r => r.Bill); 
        }

        public static Task UpdateBillAsync(this FreeAgentClient client, Bill bill)
        {
            return client.UpdateOrDeleteAsync(bill, (c, id) => c.UpdateBill(client.Configuration.CurrentHeader, id, bill.Wrap()));
        }

        public static Task<Bill> GetBillAsync(this FreeAgentClient client, Bill bill)
        {
            var id = client.ExtractId(bill);
            return client.GetBillAsync(id);
        }

        public static Task<Bill> GetBillAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetBillAsync(id);
        }

        public static Task<Bill> GetBillAsync(this FreeAgentClient client, int billId)
        {
            return client.GetOrCreateAsync(c => c.GetBill(client.Configuration.CurrentHeader, billId), r => r.Bill); 
        }

        public static Task DeleteBillAsync(this FreeAgentClient client, Bill bill)
        {
            return client.UpdateOrDeleteAsync(bill, (c,id) => c.DeleteBill(client.Configuration.CurrentHeader, id));
        }

        internal static BillWrapper Wrap(this Bill bill)
        {
            return new BillWrapper { Bill = bill };
        }
    }

    public enum BillFilter
    {
        [EnumMember(Value = "all")] All,
        [EnumMember(Value = "open")] Open,
        [EnumMember(Value = "overdue")] Overdue,
        [EnumMember(Value = "open_or_overdue")] OpenOrOverdue,
        [EnumMember(Value = "paid")] Paid,
        [EnumMember(Value = "recurring")] Recurring        
    }

    public enum BillOrder
    {
        [EnumMember(Value = "dated_on")] DatedOn,
        [EnumMember(Value = "-dated_on")] DatedOnDescending,
        [EnumMember(Value = "due_date")] DueDate,
        [EnumMember(Value = "-due_date")] DueDateDescending,
        [EnumMember(Value = "total_value")] TotalValue,
        [EnumMember(Value = "-total_value")] TotalValueDescending,
        [EnumMember(Value = "reference")] Reference,
        [EnumMember(Value = "-reference")] ReferenceDescending,
        [EnumMember(Value = "contact_display_name")] ContactDisplayName,
        [EnumMember(Value = "-contact_display_name")] ContactDisplayNameDescending
    }
}
