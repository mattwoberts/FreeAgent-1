using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
	public class TrialBalance
	{
		public Uri Category { get; set; }
		public string NominalCode { get; set; }
		public string Name { get; set; }
		public float Total { get; set; }
        public Uri BankAccount { get; set; }
        public Uri User { get; set; }
	}

	public class TrialBalanceWrapper
	{
		public IEnumerable<TrialBalance> TrialBalanceSummary { get; set; }
	}
}

