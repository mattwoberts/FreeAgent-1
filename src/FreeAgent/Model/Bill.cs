using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public class Bill : IUrl
	{
		public Bill()
		{
			ec_status = ECStatus.None;
		}

        public Uri Url { get; set; }
		public Uri Project { get; set; }
		public Uri Contact { get; set; }
		public Uri Category { get; set; }
		public string reference { get; set; }
		public DateTime DatedOn { get; set;}
		public string DueOn { get; set;}
		public double TotalValue { get; set; }
		public double PaidValue { get; set; }
		public double DueValue { get; set; }
		public double SalesTaxValue { get; set; }
		public double SalesTaxRate { get; set; }
		public double ManualSalesTaxAmount { get; set; }
		public double SecondSalesTaxRate { get; set; }

		public string recurring { get; set; }
		public string recurring_end_date { get; set; }
		public int ec_status { get; set; }
		public string status { get; set; }
		public string rebill_type { get; set; }
		public double rebill_factor { get; set;}
		public string comments { get; set; }
		public string depreciation_schedule { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

		public Attachment Attachment  { get; set;}
	}
	
	public class BillWrapper
	{
		public Bill Bill { get; set; }
		public List<Bill> bills { get; set; }
	}
}