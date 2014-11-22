using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class Expense : IUrl
	{
        public Expense()
        {
            have_vat_receipt = false;
            ec_status = ECStatus.None;
        }

        public Uri Url { get; set; }
        public Uri User { get; set; }
		public Uri Project { get; set;}
		public double gross_value { get; set;}
		public double sales_tax_rate { get; set;}
		public string description { get; set;}
		public string dated_on { get; set;}
		public string category { get; set;}
		public double mileage { get; set;}
		public double reclaim_mileage_rate { get; set;}
		public double rebill_mileage_rate { get; set;}
        public string rebill_type { get; set; }
        public double initial_rate_mileage { get; set; }
        public string receipt_reference { get; set; }
        public int ec_status { get; set; }
		public string currency { get; set; }


        public double manual_sales_tax_amount { get; set;}
		public double rebill_factor { get; set;}
        public string vehicle_type { get; set;}
        public int engine_size_index { get; set;}
        public int engine_type_index { get; set; }
        public bool have_vat_receipt { get; set; }
		public Attachment attachment  { get; set;}

        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
	
    public class ECStatus 
    {
        public const int None = 0;
        public const int Goods = 2;
        public const int Service = 1;
    }
	
	public class ExpenseWrapper
	{
		public Expense Expense { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}




