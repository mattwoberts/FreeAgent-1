using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class BankTransactionExplanation : IUrl
	{
        public Uri Url { get; set; }
	}

	public class BankTransactionExplanationWrapper
	{
		public BankTransactionExplanation BankTransactionExplanation { get; set; }
        public List<BankTransactionExplanation> BankTransactionExplanations { get; set; }
    }
}