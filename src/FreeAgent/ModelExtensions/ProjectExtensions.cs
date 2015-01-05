using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
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

            return client.GetOrCreateAsync(c => c.ProjectList(client.Configuration.CurrentHeader, view, sort, null), r => r.Projects); 
        }

        public static Task<List<Project>> GetProjectsAsync(this FreeAgentClient client, Contact contact)
        {
            var url = client.ExtractUrl(contact);
            return client.GetOrCreateAsync(c => c.ProjectList(client.Configuration.CurrentHeader, null, null, url.OriginalString), r => r.Projects);
        }

        public static Task<Project> CreateProjectAsync(this FreeAgentClient client, Project contact)
        {
            return client.GetOrCreateAsync(c => c.CreateProject(client.Configuration.CurrentHeader, contact.Wrap()), r => r.Project);
        }

        public static Task UpdateProjectAsync(this FreeAgentClient client, Project contact)
        {
            return client.UpdateOrDeleteAsync(contact, (c, id) => c.UpdateProject(client.Configuration.CurrentHeader, id, contact.Wrap()));
        }

        public static Task<Project> GetProjectAsync(this FreeAgentClient client, Project contact)
        {
            var id = client.ExtractId(contact);
            return client.GetProjectAsync(id);
        }

        public static Task<Project> GetProjectAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetProjectAsync(id);
        }

        public static Task<Project> GetProjectAsync(this FreeAgentClient client, int projectId)
        {
            return client.GetOrCreateAsync(c => c.GetProject(client.Configuration.CurrentHeader, projectId), r => r.Project);
        }

        public static Task DeleteProjectAsync(this FreeAgentClient client, Contact project)
        {
            return client.UpdateOrDeleteAsync(project, (c, id) => c.DeleteContact(client.Configuration.CurrentHeader, id));
        }

        internal static ProjectWrapper Wrap(this Project project)
        {
            return new ProjectWrapper { Project = project };
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
