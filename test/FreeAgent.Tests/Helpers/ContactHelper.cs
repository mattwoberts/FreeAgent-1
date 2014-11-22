using FreeAgent.Model;
using System;

namespace FreeAgent.Tests
{
    public static partial class Helper
    {
        public const string ContactAddress1Prefix = "Contact TEST ";

        public static Contact NewContact()
        {
            var newContact = new Contact
            {
                Locale = "en",
                FirstName = "Freesharp TEST",
                LastName = "Library",
                OrganisationName = "Freesharp Test Library",
                Address1 = Helper.ContactAddress1Prefix + Guid.NewGuid().ToString(),
            };

            return newContact;
        }
    }

}
