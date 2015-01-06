using FreeAgent.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public class Invoice : IUrl
	{
		public Invoice() 
		{
			InvoiceItems = new List<InvoiceItem>();
		}

        public Uri Url { get; set; }
		public string Reference { get; set; }
		public Uri Contact { get; set; }
		public Uri Project { get; set; }
		public InvoiceStatus Status { get; set; }
		public double DiscountPercent { get; set; } 

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime DatedOn { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime DueOn { get; set; }

        public double ExchangeRate { get; set; }
		public int PaymentTermsInDays { get; set; }
		public string Currency { get; set; }
		public InvoiceECStatus EcStatus { get; set; } 
		public DateTime WrittenOffDate { get; set; } //?
		public double NetValue { get; set; }
		public double SalesTaxValue { get; set; }
		public double DueValue { get; set; }
		public double PaidValue { get; set; } 
        public double TotalValue { get; set; }
		public string Comments { get; set; } 
        public bool AlwaysShowBicAndIban { get; set; } 
        public bool OmitHeader { get; set; } 
        public bool ShowProjectName { get; set; }
        public string PoRefernce { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

		public List<InvoiceItem> InvoiceItems { get; set; }
	}

	public class InvoiceWrapper
	{
		public Invoice Invoice { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
	}
}




