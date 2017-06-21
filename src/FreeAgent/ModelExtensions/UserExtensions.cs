using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeAgent.Helpers;

namespace FreeAgent
{
    public static class UserExtensions
    {
        public static Task<IEnumerable<User>> GetUsersAsync(this FreeAgentClient client)
        {
             return client.GetOrCreateAsync(c => c.UserList(client.Configuration.CurrentHeader), r => r.Users); 
        }

        public static Task<User> CreateUser(this FreeAgentClient client, User user)
        {
            return client.GetOrCreateAsync(c => c.CreateUser(client.Configuration.CurrentHeader, user.Wrap()), r => r.User); 
        }

        public static Task UpdateUserAsync(this FreeAgentClient client, User user)
        {
            return client.UpdateOrDeleteAsync(user, (c, id) => c.UpdateUser(client.Configuration.CurrentHeader, id, user.Wrap()));
        }

        public static Task UpdateCurrentUserAsync(this FreeAgentClient client, User user)
        {
            return client.UpdateOrDeleteAsync(user, (c, id) => c.UpdateCurrentUser(client.Configuration.CurrentHeader, user.Wrap()));
        }

        public static Task<User> GetUserAsync(this FreeAgentClient client, User user)
        {
            var id = client.ExtractId(user);
            return client.GetUserAsync(id);
        }

        public static Task<User> GetUserAsync(this FreeAgentClient client, Uri url)
        {
            var id = url.GetId();
            return client.GetUserAsync(id);
        }

        public static Task<User> GetUserAsync(this FreeAgentClient client, int userId)
        {
            return client.GetOrCreateAsync(c => c.GetUser(client.Configuration.CurrentHeader, userId), r => r.User);
        }

        public static Task<User> GetCurrentUserAsync(this FreeAgentClient client)
        {
            return client.GetOrCreateAsync(c => c.GetCurrentUser(client.Configuration.CurrentHeader), r => r.User);
        }

        public static Task DeleteContactAsync(this FreeAgentClient client, User user)
        {
            return client.UpdateOrDeleteAsync(user, (c, id) => c.DeleteUser(client.Configuration.CurrentHeader, id));
        }


        internal static UserWrapper Wrap(this User user)
        {
            return new UserWrapper { User = user };
        }
    }
}
