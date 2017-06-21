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
        public Uri PaidInvoice { get; set; }
        public Attachment Attachment { get; set; }
	    public double GrossValue { get; set; }
	    public double ForeignCurrencyValue { get; set; }
    }

    public class BankTransactionExplanationWrapper
	{
		public BankTransactionExplanation BankTransactionExplanation { get; set; }
        //public IEnumerable<BankTransactionExplanation> BankTransactionExplanations { get; set; }
    }
}