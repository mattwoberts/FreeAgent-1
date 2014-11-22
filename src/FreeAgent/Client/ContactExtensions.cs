using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class ContactExtensions
    {
        public static async Task<List<Contact>> GetContactsAsync(this FreeAgentClient client, ContactViewFilter filter = null)
        {
            var result = await client.Execute(c =>
            {
                var myFilter = filter ?? ContactViewFilter.All();

                return c.GetContactList(client.Configuration.CurrentHeader, myFilter.FilterValue, myFilter.SortValue);
            });

            return result.Contacts;
        }

        public static async Task<Contact> CreateContactAsync(this FreeAgentClient client, Contact contact)
        {
            var result = await client.Execute(c =>
            {
                var source = new ContactWrapper { Contact = contact };

                return c.CreateContact(client.Configuration.CurrentHeader, source);
            });

            return result.Contact;
        }

        public static async Task<Contact> GetContactAsync(this FreeAgentClient client, Uri url)
        {
            var result = await client.Execute(c =>
            {
                var id = client.ExtractId(url);
                return client.Client.GetContact(client.Configuration.CurrentHeader, id);
            });

            return result.Contact;
        }

        public static async Task<Contact> GetContactAsync(this FreeAgentClient client, int accountId)
        {
            var result = await client.Execute(c =>
            {
                return client.Client.GetContact(client.Configuration.CurrentHeader, accountId);
            });

            return result.Contact;
        }

        public static async Task<bool> DeleteContactAsync(this FreeAgentClient client, Contact contact)
        {
            var result = await client.Execute(async c =>
            {
                //TODO - safety stuff here??

                var id = client.ExtractId(contact);

                await client.Client.DeleteContact(client.Configuration.CurrentHeader, id);
                return true;
            });

            return true;
        }

    }


    //TODO - sort value

    public class ContactViewFilter
    {
        internal string FilterValue { get; set; }
        internal string SortValue { get; set; }

            // show all projects 
        public static ContactViewFilter All() 
        {
            return new ContactViewFilter { FilterValue = "all" };
        }

        public static ContactViewFilter Active()
        {
            return new ContactViewFilter { FilterValue = "active" };
        }

        public static ContactViewFilter Complete()
        {
            return new ContactViewFilter { FilterValue = "clients" };
        }

        public static ContactViewFilter Cancelled()
        {
            return new ContactViewFilter { FilterValue = "suppliers" };
        }

        public static ContactViewFilter ActiveProjects()
        {
            return new ContactViewFilter { FilterValue = "active_projects" };
        }

        public static ContactViewFilter CompletedProjects()
        {
            return new ContactViewFilter { FilterValue = "completed_projects" };
        }

        public static ContactViewFilter ClientsWithOpenInvoices()
        {
            return new ContactViewFilter { FilterValue = "open_clients" };
        }

        public static ContactViewFilter SuppliersWithOpenBills()
        {
            return new ContactViewFilter { FilterValue = "open_suppliers" };
        }

        public static ContactViewFilter Hidden()
        {
            return new ContactViewFilter { FilterValue = "hidden" };
        }
    }
}
