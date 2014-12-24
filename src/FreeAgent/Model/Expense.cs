using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class Expense : IUrl
	{
        public Expense()
        {
            HaveVatReceipt = false;
            EcStatus = ECStatus.None;
        }

        public Uri Url { get; set; }
        public Uri User { get; set; }
		public Uri Project { get; set;}
		public double GrossValue { get; set;}
		public double SalesTaxRate { get; set;}
		public string Description { get; set;}
		public DateTime DatedOn { get; set;}
		public Uri Category { get; set;}
		public double Mileage { get; set;}
		public double ReclaimMileageRate { get; set;}
		public double RebillMileageRate { get; set;}
        public string RebillType { get; set; }
        public double InitialRateMileage { get; set; }
        public string ReceiptReference { get; set; }
        public ECStatus EcStatus { get; set; }
		public string Currency { get; set; }
        public double ManualSalesTaxAmount { get; set;}
		public double RebillFactor { get; set;}
        public string VehicleType { get; set;}
        public int EngineSizeIndex { get; set;}
        public int EngineTypeIndex { get; set; }
        public bool HaveVatReceipt { get; set; }
		public Attachment Attachment  { get; set;}
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
	
	public class ExpenseWrapper
	{
		public Expense Expense { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}




