using FreeAgent.Helpers;
using Newtonsoft.Json;
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

        [JsonConverter(typeof(IsoDateConverter))]
		public DateTime DatedOn { get; set;}

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime DueOn { get; set;} 

		public double TotalValue { get; set; }
		public double PaidValue { get; set; }
		public double DueValue { get; set; }
		public double SalesTaxValue { get; set; }//?
		public double SalesTaxRate { get; set; }//?
		public double ManualSalesTaxAmount { get; set; }//?
		public double SecondSalesTaxRate { get; set; }//?
		public ECStatus EcStatus { get; set; }//?
		public BillStatus Status { get; set; } 
        public Uri RebillToProject { get; set; }
		public RebillType RebillType { get; set; }
		public double RebillFactor { get; set;}//?
        public Frequency Recurring { get; set; } 

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime? RecurringEndDate { get; set; } 

        public string Comments { get; set; }
		public string DepreciationSchedule { get; set; }//?
        public Attachment Attachment { get; set; }//?
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
	}
	
	public class BillWrapper
	{
		public Bill Bill { get; set; }
		public List<Bill> Bills { get; set; }
	}
}