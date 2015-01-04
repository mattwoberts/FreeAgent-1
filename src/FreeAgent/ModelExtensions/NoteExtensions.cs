using FreeAgent.Model;
using System;
using System.Threading.Tasks;
using FreeAgent.Helpers;
using System.Collections.Generic;

namespace FreeAgent
{
    public static class NoteExtensions
    {
        public static Task<List<NoteItem>> GetNotesAsync(this FreeAgentClient client, Contact contact)
        {
            var url = client.ExtractUrl(contact);
            return client.GetOrCreateAsync(c => c.NoteList(client.Configuration.CurrentHeader, url.OriginalString, null), r => r.Notes);
        }

        public static Task<List<NoteItem>> GetNotesAsync(this FreeAgentClient client, Project project)
        {
            var url = client.ExtractUrl(project);
            return client.GetOrCreateAsync(c => c.NoteList(client.Configuration.CurrentHeader, null, url.OriginalString), r => r.Notes); 
        }

        public static Task<NoteItem> GetNoteAsync(this FreeAgentClient client, NoteItem note)
        {
            var id = client.ExtractId(note);
            return client.GetNoteAsync(id);
        }

        public static Task<NoteItem> GetNoteAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetNoteAsync(id);
        }

        public static Task<NoteItem> GetNoteAsync(this FreeAgentClient client, int noteId)
        {
            return client.GetOrCreateAsync(c => c.GetNote(client.Configuration.CurrentHeader, noteId), r => r.Note); 
        }

        public static Task DeleteNoteAsync(this FreeAgentClient client, NoteItem note)
        {
            return client.UpdateOrDeleteAsync(note, (c, id) => c.DeleteNote(client.Configuration.CurrentHeader, id));
        }

        internal static NoteItemWrapper Wrap(this NoteItem note)
        {
            return new NoteItemWrapper { Note = note };
        }
    }
}
