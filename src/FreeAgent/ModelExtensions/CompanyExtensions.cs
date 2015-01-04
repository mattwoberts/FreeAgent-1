using FreeAgent.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class CompanyExtensions
    {
        public static Task<Company> GetCompanyAsync(this FreeAgentClient client)
        {
            return client.GetOrCreateAsync(c => c.CompanyDetails(client.Configuration.CurrentHeader), r => r.Company);
        }

        public static Task<List<TaxTimeline>> GetTaxTimelinesAsync(this FreeAgentClient client)
        {
            return client.GetOrCreateAsync(c => c.TaxTimelines(client.Configuration.CurrentHeader), r => r.TimelineItems); 
        }
    }
}
