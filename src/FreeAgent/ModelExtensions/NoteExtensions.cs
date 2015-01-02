using FreeAgent.Model;
using System;
using System.Threading.Tasks;
using FreeAgent.Helpers;
using System.Collections.Generic;

namespace FreeAgent
{
    public static class NoteExtensions
    {
        public static async Task<List<NoteItem>> GetNotesAsync(this FreeAgentClient client, Contact contact)
        {
            var url = client.ExtractUrl(contact);

            var result = await client.Execute(c => c.NoteList(client.Configuration.CurrentHeader, url.OriginalString, null));
            return result.Notes;
        }

        public static async Task<List<NoteItem>> GetNotesAsync(this FreeAgentClient client, Project project)
        {
            var url = client.ExtractUrl(project);
            var result = await client.Execute(c => c.NoteList(client.Configuration.CurrentHeader, null, url.OriginalString));
            return result.Notes;
        }

        public static async Task<NoteItem> GetNoteAsync(this FreeAgentClient client, NoteItem note)
        {
            var id = client.ExtractId(note);
            return await client.GetNoteAsync(id);
        }

        public static async Task<NoteItem> GetNoteAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return await client.GetNoteAsync(id);
        }

        public static async Task<NoteItem> GetNoteAsync(this FreeAgentClient client, int noteId)
        {
            var result = await client.Execute(c => c.GetNote(client.Configuration.CurrentHeader, noteId));
            return result.Note;
        }

        public static async Task<bool> DeleteNoteAsync(this FreeAgentClient client, NoteItem note)
        {
            var id = client.ExtractId(note);

            await client.Execute(c => c.DeleteNote(client.Configuration.CurrentHeader, id));
            return true;
        }

        internal static NoteItemWrapper Wrap(this NoteItem note)
        {
            return new NoteItemWrapper { Note = note };
        }

    }
}
