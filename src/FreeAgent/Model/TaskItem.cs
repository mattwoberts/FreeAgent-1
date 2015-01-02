using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class TaskItem : IUrl
	{
        public Uri Url { get; set; }
		public Uri Project { get; set; }
		public string Name { get; set; }
		public bool IsBillable { get; set; }
		public double BillingRate { get; set; }
        public BillingPeriod BillingPeriod { get; set; }
        public TaskStatus Status { get; set; }
	}

	public class TaskItemWrapper
	{
		public TaskItem Task { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}

