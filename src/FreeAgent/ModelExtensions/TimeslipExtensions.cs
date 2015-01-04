using FreeAgent.Model;
using System;
using System.Threading.Tasks;
using FreeAgent.Helpers;
using System.Collections.Generic;

namespace FreeAgent
{
    public static class TimeslipExtensions
    {
        public static async Task<List<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var result = await client.Execute(c => c.TimeslipList(client.Configuration.CurrentHeader, null, null, null, fromDate, toDate));
            return result.Timeslips;
        }

        public static async Task<List<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, User user)
        {
            var url = client.ExtractUrl(user);
            var result = await client.Execute(c => c.TimeslipList(client.Configuration.CurrentHeader, url.OriginalString, null, null, null, null));
            return result.Timeslips;
        }

        public static async Task<List<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, TaskItem task)
        {
            var url = client.ExtractUrl(task);
            var result = await client.Execute(c => c.TimeslipList(client.Configuration.CurrentHeader, null, url.OriginalString, null, null, null));
            return result.Timeslips;
        }

        public static async Task<List<Timeslip>> GetTimeSlipsAsync(this FreeAgentClient client, Project project)
        {
            var url = client.ExtractUrl(project);
            var result = await client.Execute(c => c.TimeslipList(client.Configuration.CurrentHeader, null, null, url.OriginalString, null, null));
            return result.Timeslips;
        }

        public static async Task<Timeslip> GetTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            var id = client.ExtractId(timeslip);
            return await client.GetTimeslipAsync(id);
        }

        public static async Task<Timeslip> GetTimeslipAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return await client.GetTimeslipAsync(id);
        }

        public static async Task<Timeslip> GetTimeslipAsync(this FreeAgentClient client, int timeslipId)
        {
            var result = await client.Execute(c => c.GetTimeslip(client.Configuration.CurrentHeader, timeslipId));
            return result.Timeslip;
        }

        public static async Task<Timeslip> CreateTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            var result = await client.Execute(c => c.CreateTimeslips(client.Configuration.CurrentHeader, timeslip.Wrap()));
            return result.Timeslip;
        }

        public static async Task<List<Timeslip>> CreateTimeslipAsync(this FreeAgentClient client, List<Timeslip> timeslips)
        {
            var result = await client.Execute(c => c.CreateTimeslips(client.Configuration.CurrentHeader, timeslips.Wrap()));
            return result.Timeslips;
        }

        public static async Task<bool> UpdateTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            var id = client.ExtractId(timeslip);

            await client.Execute(c => c.UpdateTimeslip(client.Configuration.CurrentHeader, id, timeslip.Wrap()));
            return true;
        }

        public static async Task<bool> DeleteTimeslipAsync(this FreeAgentClient client, Timeslip timeslip)
        {
            var id = client.ExtractId(timeslip);

            await client.Execute(c => c.DeleteNote(client.Configuration.CurrentHeader, id));
            return true;
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
