using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class Project : IUrl
	{
		public Project() : base()
		{
			Name = "";
			Status = ProjectStatus.Active;
			BudgetUnits = BudgetUnits.Hours;
			Currency = "GBP";
            BillingPeriod = BillingPeriod.Hour;
		}

        public Uri Url { get; set; }
		public Uri Contact { get; set; }
		public string Name { get; set; }
		public DateTime StartsOn { get; set; }
		public DateTime? EndsOn { get; set; } //TODO - check this
		public double Budget { get; set; }
		public bool IsIr35 { get; set; }
		public string ContractPoReference { get; set; }
        public ProjectStatus Status { get; set; }
        public BudgetUnits BudgetUnits { get; set; }
		public double NormalBillingRate { get; set; }
		public double HoursPerDay { get; set; }
		public bool UsesProjectInvoiceSequence { get; set; }
		public string Currency { get; set; }
		public BillingPeriod BillingPeriod { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
	}
	
	public class ProjectWrapper
	{
		public Project Project { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}