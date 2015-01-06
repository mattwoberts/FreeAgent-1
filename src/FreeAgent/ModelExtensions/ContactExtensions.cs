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
        public static Task<IEnumerable<Contact>> GetContactsAsync(this FreeAgentClient client, ContactFilter filterBy = ContactFilter.All, ContactOrder orderBy = ContactOrder.Name)
        {
            var view = filterBy.GetMemberValue();
            var sort = orderBy.GetMemberValue();

            return client.GetOrCreateAsync(c => c.ContactList(client.Configuration.CurrentHeader, view, sort), r => r.Contacts); 
        }

        public static Task<Contact> CreateContactAsync(this FreeAgentClient client, Contact contact)
        {
            return client.GetOrCreateAsync(c => c.CreateContact(client.Configuration.CurrentHeader, contact.Wrap()), r => r.Contact); 
        }

        public static Task UpdateContactAsync(this FreeAgentClient client, Contact contact)
        {
            return client.UpdateOrDeleteAsync(contact, (c, id) => c.UpdateContact(client.Configuration.CurrentHeader, id, contact.Wrap()));
        }

        public static Task<Contact> GetContactAsync(this FreeAgentClient client, Contact contact)
        {
            var id = client.ExtractId(contact);
            return client.GetContactAsync(id);
        }

        public static Task<Contact> GetContactAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetContactAsync(id);
        }

        public static Task<Contact> GetContactAsync(this FreeAgentClient client, int contactId)
        {
            return client.GetOrCreateAsync(c => c.GetContact(client.Configuration.CurrentHeader, contactId), r => r.Contact); 
        }

        public static Task DeleteContactAsync(this FreeAgentClient client, Contact contact)
        {
            return client.UpdateOrDeleteAsync(contact, (c,id) => c.DeleteContact(client.Configuration.CurrentHeader, id));
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
