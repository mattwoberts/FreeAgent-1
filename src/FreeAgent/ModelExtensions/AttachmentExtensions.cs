using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class AttachmentExtensions
    {
        public static async Task<Attachment> GetAttachmentAsync(this FreeAgentClient client, Attachment attachment)
        {
            var id = client.ExtractId(attachment);
            return await client.GetAttachmentAsync(id);
        }

        public static async Task<Attachment> GetAttachmentAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return await client.GetAttachmentAsync(id);
        }

        public static async Task<Attachment> GetAttachmentAsync(this FreeAgentClient client, int attachmentId)
        {
            var result = await client.Execute(c => c.GetAttachment(client.Configuration.CurrentHeader, attachmentId));
            return result.Attachment;
        }

        public static async Task<bool> DeleteContactAsync(this FreeAgentClient client, Attachment attachment)
        {
            var id = client.ExtractId(attachment);

            await client.Execute(c => c.DeleteAttachment(client.Configuration.CurrentHeader, id));
            return true;
        }
    }
}
