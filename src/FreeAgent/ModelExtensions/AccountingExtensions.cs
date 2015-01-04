using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class AccountingExtensions
    {
        public static Task<List<TrialBalance>> GetTrialBalanceAsync(this FreeAgentClient client, DateTime? date)
        {
            return client.GetOrCreateAsync(c => c.TrialBalanceList(client.Configuration.CurrentHeader, date), r => r.TrialBalanceSummary);
        }

        public static Task<List<TrialBalance>> GetOpeningBalanceAsync(this FreeAgentClient client)
        {
            return client.GetOrCreateAsync(c => c.OpeningBalanceList(client.Configuration.CurrentHeader), r => r.TrialBalanceSummary); 
        }
    }
}
