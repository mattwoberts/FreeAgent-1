using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class BankTransaction : IUrl
	{
        public Uri Url { get; set; }
        public Uri BankAccount { get; set; }
		public double Amount { get; set; }
		public DateTime DatedOn { get; set; }
		public string Description { get; set; }
		public double UnexplainedAmount { get; set; }
		public bool IsManual { get; set; }

        public List<BankTransactionExplanation> BankTransactionExplanations { get; set; }
	}

	public class BankTransactionWrapper
	{
		public BankTransaction BankTransaction { get; set; }
        public List<BankTransaction> BankTransactions { get; set; }
    }
}