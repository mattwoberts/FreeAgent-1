using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class TimeslipExtensions
    {
        public static Task<IEnumerable<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return client.GetOrCreateAsync(c => c.TimeslipList(client.Configuration.CurrentHeader, null, null, null, fromDate, toDate), r => r.Timeslips);
        }

        public static Task<IEnumerable<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, User user)
        {
            var url = client.ExtractUrl(user);
            return client.GetOrCreateAsync(c => c.TimeslipList(client.Configuration.CurrentHeader, url.OriginalString, null, null, null, null), r => r.Timeslips);
        }

        public static Task<IEnumerable<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, TaskItem task)
        {
            var url = client.ExtractUrl(task);
            return client.GetOrCreateAsync(c => c.TimeslipList(client.Configuration.CurrentHeader, null, url.OriginalString, null, null, null), r => r.Timeslips);
        }

        public static Task<IEnumerable<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, Project project)
        {
            var url = client.ExtractUrl(project);
            return client.GetOrCreateAsync(c => c.TimeslipList(client.Configuration.CurrentHeader, null, null, url.OriginalString, null, null), r => r.Timeslips);
        }

        public static Task<Timeslip> GetTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            var id = client.ExtractId(timeslip);
            return client.GetTimeslipAsync(id);
        }

        public static Task<Timeslip> GetTimeslipAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetTimeslipAsync(id);
        }

        public static Task<Timeslip> GetTimeslipAsync(this FreeAgentClient client, int timeslipId)
        {
            return client.GetOrCreateAsync(c => c.GetTimeslip(client.Configuration.CurrentHeader, timeslipId), r => r.Timeslip); 
        }

        public static Task<Timeslip> CreateTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            return client.GetOrCreateAsync(c => c.CreateTimeslips(client.Configuration.CurrentHeader, timeslip.Wrap()), r => r.Timeslip);
        }

        public static Task<IEnumerable<Timeslip>> CreateTimeslipAsync(this FreeAgentClient client, List<Timeslip> timeslips)
        {
            return client.GetOrCreateAsync(c => c.CreateTimeslips(client.Configuration.CurrentHeader, timeslips.Wrap()), r => r.Timeslips);
        }

        public static Task UpdateTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            return client.UpdateOrDeleteAsync(timeslip, (c, id) => c.UpdateTimeslip(client.Configuration.CurrentHeader, id, timeslip.Wrap()));
        }

        public static Task DeleteTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            return client.UpdateOrDeleteAsync(timeslip, (c, id) => c.DeleteBankAccount(client.Configuration.CurrentHeader, id));
        }

        internal static TimeslipWrapper Wrap(this Timeslip timeslip)
        {
            return new TimeslipWrapper { Timeslip = timeslip };
        }
        internal static TimeslipWrapper Wrap(this List<Timeslip> timeslips)
        {
            return new TimeslipWrapper { Timeslips = timeslips };
        }
    }
}
