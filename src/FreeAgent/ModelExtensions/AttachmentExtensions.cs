using FreeAgent.Model;
using System;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class AttachmentExtensions
    {
        public static Task<Attachment> GetAttachmentAsync(this FreeAgentClient client, Attachment attachment)
        {
            var id = client.ExtractId(attachment);
            return client.GetAttachmentAsync(id);
        }

        public static Task<Attachment> GetAttachmentAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetAttachmentAsync(id);
        }

        public static Task<Attachment> GetAttachmentAsync(this FreeAgentClient client, int attachmentId)
        {
            return client.GetOrCreateAsync(c => c.GetAttachment(client.Configuration.CurrentHeader, attachmentId), r => r.Attachment); 
        }

        public static Task DeleteContactAsync(this FreeAgentClient client, Attachment attachment)
        {
            return client.UpdateOrDeleteAsync(attachment, (c, id) => c.DeleteAttachment(client.Configuration.CurrentHeader, id));
        }
    }
}
