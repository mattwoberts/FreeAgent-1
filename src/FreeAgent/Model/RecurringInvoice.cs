using FreeAgent.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class RecurringInvoice : IUrl
	{
		public RecurringInvoice() 
		{
			InvoiceItems = new List<InvoiceItem>();
		}

        public Uri Url { get; set; }
        public Uri Project { get; set; }
        public Uri Contact { get; set; }
        public string Comments { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime DatedOn { get; set; }

        public Frequency Frequency { get; set; }
        public RecurringInvoiceStatus RecurringStatus { get; set; }
        public string Reference { get; set; }
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double NetValue { get; set; }
        public double SalesTaxValue { get; set; }
        public double TotalValue { get; set; }
        public double DiscountPercent { get; set; }
        public bool OmitHeader { get; set; }
        public int PaymentTermsInDays { get; set; }
		public List<InvoiceItem> InvoiceItems { get; set; }
	}

	public class RecurringInvoiceWrapper
	{
		public RecurringInvoice RecurringInvoice { get; set; }
        public IEnumerable<RecurringInvoice> RecurringInvoices { get; set; }
	}
}




