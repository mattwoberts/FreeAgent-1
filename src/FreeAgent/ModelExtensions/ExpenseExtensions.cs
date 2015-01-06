using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class ExpenseExtensions
    {
        public static Task<IEnumerable<Expense>> GetExpensesAsync(this FreeAgentClient client, ExpenseFilter filterBy = ExpenseFilter.All, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var view = filterBy.GetMemberValue();
            return client.GetOrCreateAsync(c => c.ExpenseList(client.Configuration.CurrentHeader, view, fromDate, toDate), r => r.Expenses); 
        }

        public static Task<Expense> CreateExpenseAsync(this FreeAgentClient client, Expense expense)
        {
            return client.GetOrCreateAsync(c => c.CreateExpense(client.Configuration.CurrentHeader, expense.Wrap()), r => r.Expense); 
        }

        public static Task UpdateExpenseAsync(this FreeAgentClient client, Expense expense)
        {
            return client.UpdateOrDeleteAsync(expense, (c, id) => c.UpdateExpense(client.Configuration.CurrentHeader, id, expense.Wrap()));
        }

        public static Task<Expense> GetExpenseAsync(this FreeAgentClient client, Expense expense)
        {
            var id = client.ExtractId(expense);
            return client.GetExpenseAsync(id);
        }

        public static Task<Expense> GetExpenseAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetExpenseAsync(id);
        }

        public static Task<Expense> GetExpenseAsync(this FreeAgentClient client, int expenseId)
        {
            return client.GetOrCreateAsync(c => c.GetExpense(client.Configuration.CurrentHeader, expenseId), r => r.Expense); 
        }

        public static Task DeleteExpenseAsync(this FreeAgentClient client, Expense expense)
        {
            return client.UpdateOrDeleteAsync(expense, (c,id) => c.DeleteExpense(client.Configuration.CurrentHeader, id));
        }

        internal static ExpenseWrapper Wrap(this Expense expense)
        {
            return new ExpenseWrapper { Expense = expense };
        }
    }

    public enum ExpenseFilter
    {
        [EnumMember(Value = null)] All,
        [EnumMember(Value = "recent")] Recent,
        [EnumMember(Value = "recurring")] Recurring        
    }
}
