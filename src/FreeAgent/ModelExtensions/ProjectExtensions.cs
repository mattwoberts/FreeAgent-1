using FreeAgent.Helpers;
using FreeAgent.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class ProjectExtensions
    {
        public static Task<List<Project>> GetProjectsAsync(this FreeAgentClient client, ProjectFilter filterBy = ProjectFilter.All, ProjectOrder orderBy = ProjectOrder.Name)
        {
            var view = filterBy.GetMemberValue();
            var sort = orderBy.GetMemberValue();

            return client.GetOrCreateAsync(c => c.ProjectList(client.Configuration.CurrentHeader, view, sort), r => r.Projects); 
        }
    }

    public enum ProjectFilter
    {
        [EnumMember(Value = null)] All,
        [EnumMember(Value = "active")] Active,
        [EnumMember(Value = "completed")] Completed,
        [EnumMember(Value = "cancelled")] Cancelled,
        [EnumMember(Value = "hidden")] Hidden
    }

    public enum ProjectOrder
    {
        [EnumMember(Value = "name")] Name,
        [EnumMember(Value = "-name")] NameDescending,
        [EnumMember(Value = "created_at")] CreatedAt, //TODO - test
        [EnumMember(Value = "-created_at")] CreatedAtDescending, //TODO - test
        [EnumMember(Value = "updated_at")] UpdatedAt, //TODO - test
        [EnumMember(Value = "-updated_at")] UpdatedAtDescending, //TODO - test
        [EnumMember(Value = "contact_name")] ContactName,
        [EnumMember(Value = "-contact_name")] ContactNameDescending,
        [EnumMember(Value = "invoice_total")] InvoiceTotal, 
        [EnumMember(Value = "-invoice_total")] InvoiceTotalDescending, 
        [EnumMember(Value = "ends_on")] EndsOn, 
        [EnumMember(Value = "-ends_on")] EndsOnDescending, 
        [EnumMember(Value = "budget")] Budget,
        [EnumMember(Value = "-budget")] BudgetDescending
    }
}
