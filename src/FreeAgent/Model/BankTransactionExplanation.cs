using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class BankTransactionExplanation : IUrl
	{
        public Uri Url { get; set; }
        public Uri BankAccount { get; set; } //TODO - accoutn or transaction when creating
        public Uri BankTransaction { get; set; }
        public DateTime DatedOn { get; set; }
        public string Description { get; set; }
        public Uri Category { get; set; }

//        public double manual_sales_tax_amount
//        public double gross_value
//        public double foreign_currency_value
//rebill_type
//rebill_factor
//paid_invoice (Required when paying an invoice)
//paid_bill (Required when paying a bill receipt)
//paid_user (Required when paying a user)
//transfer_bank_account (Required when transferring money between accounts)
//asset_life_years (Required for capital asset purchase. The integer number of years over which the asset should be depreciated.)

        public Attachment Attachment { get; set; }
	}

	public class BankTransactionExplanationWrapper
	{
		public BankTransactionExplanation BankTransactionExplanation { get; set; }
        public List<BankTransactionExplanation> BankTransactionExplanations { get; set; }
    }
}