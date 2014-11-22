using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class Contact : IUrl
	{
        public Uri Url { get; set; }
        public string Locale { get; set; }
		public double AccountBalance { get; set; }
		public string OrganisationName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
        public string BillingEmail { get; set; }
		public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
		public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
		public string Region { get; set; }
		public string Postcode { get; set; }
		public bool ContactNameOnInvoices { get; set; }
		public string Country { get; set; }
		public string SalesTaxRegistrationNumber { get; set; }
		public bool UsesContactInvoiceSequence { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
	
	public class ContactWrapper
	{
		public Contact Contact { get; set; }
		public List<Contact> Contacts { get; set; }
	}
}
