using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class ContactExtensions
    {
        public static async Task<List<Contact>> GetContactsAsync(this FreeAgentClient client, ContactFilter filterBy = ContactFilter.All, ContactOrder orderBy = ContactOrder.Name)
        {
            var view = filterBy.GetMemberValue();
            var sort = orderBy.GetMemberValue();

            var result = await client.Execute(c => c.ContactList(client.Configuration.CurrentHeader, view, sort));
            return result.Contacts;
        }

        public static async Task<Contact> CreateContactAsync(this FreeAgentClient client, Contact contact)
        {
            var result = await client.Execute(c => c.CreateContact(client.Configuration.CurrentHeader, contact.Wrap()));
            return result.Contact;
        }

        public static async Task<bool> UpdateContactAsync(this FreeAgentClient client, Contact contact)
        {
            var id = client.ExtractId(contact);

            await client.Execute(c => c.UpdateContact(client.Configuration.CurrentHeader, id, contact.Wrap()));
            return true;
        }

        public static async Task<Contact> GetContactAsync(this FreeAgentClient client, Contact contact)
        {
            var id = client.ExtractId(contact);
            return await client.GetContactAsync(id);
        }

        public static async Task<Contact> GetContactAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return await client.GetContactAsync(id);
        }

        public static async Task<Contact> GetContactAsync(this FreeAgentClient client, int contactId)
        {
            var result = await client.Execute(c => c.GetContact(client.Configuration.CurrentHeader, contactId));
            return result.Contact;
        }

        public static async Task<bool> DeleteContactAsync(this FreeAgentClient client, Contact contact)
        {
            var id = client.ExtractId(contact);

            await client.Execute(c => c.DeleteContact(client.Configuration.CurrentHeader, id));
            return true;
        }

        internal static ContactWrapper Wrap(this Contact contact)
        {
            return new ContactWrapper { Contact = contact };
        }
    }

    public enum ContactFilter
    {
        [EnumMember(Value = "all")] All,
        [EnumMember(Value = "active")] Active,
        [EnumMember(Value = "clients")] Clients,
        [EnumMember(Value = "suppliers")] Suppliers,
        [EnumMember(Value = "active_projects")] ClientsWithActiveProjects,
        [EnumMember(Value = "completed_projects")] ClientsWithCompletedProjects,        
        [EnumMember(Value = "open_clients")] ClientsWithOpenInvoices,
        [EnumMember(Value = "open_suppliers")] SuppliersWithOpenBills,
        [EnumMember(Value = "hidden")] Hidden
    }

    public enum ContactOrder
    {
        [EnumMember(Value = "name")] Name,
        [EnumMember(Value = "-name")] NameDescending,
        [EnumMember(Value = "created_at")] CreatedAt,
        [EnumMember(Value = "-created_at")] CreatedAtDescending,
        [EnumMember(Value = "updated_at")] UpdatedAt,
        [EnumMember(Value = "-updated_at")] UpdatedAtDescending
    }

}
