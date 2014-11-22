using FreeAgent.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class ProjectExtensions
    {
        public static async Task<List<Project>> GetProjectsAsync(this FreeAgentClient client, ProjectViewFilter invoiceFilter = null)
        {
            var result = await client.Client.GetProjectList(client.Configuration.CurrentHeader, invoiceFilter.FilterValue);
            return result.Projects;
        }
    }

    public class ProjectViewFilter
    {
        internal string FilterValue { get; set; }

        // show all projects 
        public static ProjectViewFilter All() 
        {
            return new ProjectViewFilter { FilterValue = null };
        }
        
        // show only active projects 
        public static ProjectViewFilter Active()
        {
            return new ProjectViewFilter { FilterValue = "active"};
        }

        // Show only completed projects.
        public static ProjectViewFilter Complete()
        {
            return new ProjectViewFilter { FilterValue = "completed"};
        }
        
        // Show only cancelled projects.
        public static ProjectViewFilter Cancelled()
        {
            return new ProjectViewFilter { FilterValue = "cancelled"};
        }

        // Show only hidden projects.
        public static ProjectViewFilter Hidden()
        {
            return new ProjectViewFilter { FilterValue = "hidden"};
        }
    }
}
