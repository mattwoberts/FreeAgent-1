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
		public DateTime DatedOn { get; set; }
		public DateTime DueOn { get; set; }
		public double ExchangeRate { get; set; }
		public int PaymentTermsInDays { get; set; }
		public string Currency { get; set; }
		public InvoiceECStatus EcStatus { get; set; } // should be an enum
		public DateTime WrittenOffDate { get; set; }
		public double NetValue { get; set; }
		public double SalesTaxValue { get; set; }
		public double DueValue { get; set; }
		public double PaidValue { get; set; }
		public string Comments { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

		public List<InvoiceItem> InvoiceItems { get; set; }
	}

	public class InvoiceItem
	{
		public int Position { get; set; }
        public InvoiceItemType ItemType { get; set; }
		public double Quantity { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public double SalesTaxRate { get; set; }
		public double SecondSalesTaxRate { get; set; }
		public Uri Category { get; set; }
	}

	public enum InvoiceStatus
	{
        [EnumMember(Value = "Draft")] Draft,
		[EnumMember(Value = "Scheduled")] Scheduled,
		[EnumMember(Value = "Sent")] Sent,
		[EnumMember(Value = "Cancelled")] Cancelled 
	}

	public enum InvoiceECStatus
	{
        [EnumMember(Value = "Non-Ec")] NonEc,
        [EnumMember(Value = "EC Goods")] ECGoods,
        [EnumMember(Value = "EC Services")] ECServices
	}

	public enum InvoiceItemType
	{
		[EnumMember(Value = "Hours")] Hours,
		[EnumMember(Value = "Days")] Days,
		[EnumMember(Value = "Weeks")] Weeks,
		[EnumMember(Value = "Months")] Months,
		[EnumMember(Value = "Years")]  Years,
		[EnumMember(Value = "Products")] Products,
		[EnumMember(Value = "Services")] Services,
		[EnumMember(Value = "Training")] Training,
		[EnumMember(Value = "Expenses")] Expenses,
		[EnumMember(Value = "Comment")]  Comment,
		[EnumMember(Value = "Bills")]  Bills,
		[EnumMember(Value = "Discount")] Discount,
		[EnumMember(Value = "Credit")] Credit,
		[EnumMember(Value = "VAT")] VAT,
		[EnumMember(Value = "No Unit")] NoUnit
	}

	public class InvoiceWrapper
	{
		public Invoice Invoice { get; set; }
		public List<Invoice> Invoices { get; set; }
	}
}




