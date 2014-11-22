using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
	public class TrialBalanceSummary
	{
		public Uri Category { get; set; }
		public string NominalCode { get; set; }
		public string Name { get; set; }
		public float Total { get; set; }
	}

	public class TrialBalanceSummaryWrapper
	{
		public List<TrialBalanceSummary> TrialBalanceSummary { get; set; }
	}
}

