using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public class Bill : IUrl
	{
		public Bill()
		{
			EcStatus = ECStatus.None;
		}

        public Uri Url { get; set; }
		public Uri Project { get; set; }
		public Uri Contact { get; set; }
		public Uri Category { get; set; }
		public string Reference { get; set; }
		public DateTime DatedOn { get; set;}
		public DateTime? DueOn { get; set;} //TODO - check this?
		public double TotalValue { get; set; }
		public double PaidValue { get; set; }
		public double DueValue { get; set; }
		public double SalesTaxValue { get; set; }
		public double SalesTaxRate { get; set; }
		public double ManualSalesTaxAmount { get; set; }
		public double SecondSalesTaxRate { get; set; }
		public string Recurring { get; set; } //TODO - check this
		public DateTime? RecurringEndDate { get; set; }  // TODO - check this
		public ECStatus EcStatus { get; set; }
		public string Status { get; set; }
		public string RebillType { get; set; }
		public double RebillFactor { get; set;}
		public string Comments { get; set; }
		public string DepreciationSchedule { get; set; }
        public Attachment Attachment { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
	}
	
	public class BillWrapper
	{
		public Bill Bill { get; set; }
		public List<Bill> bills { get; set; }
	}
}