using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public class TaskItem : IUrl
	{
        public Uri Url { get; set; }
		public Uri Project { get; set; }
		public string Name { get; set; }
		public bool IsBillable { get; set; }
		public double BillingRate { get; set; }
        public TaskBillingPeriod BillingPeriod { get; set; }
        public TaskStatus Status { get; set; }
	}

    public enum TaskBillingPeriod
    {
        [EnumMember(Value = "hour")] Hour,
        [EnumMember(Value = "day")] Day
    }

    public enum TaskStatus 
    {
        [EnumMember(Value = "Active")] Active,
        [EnumMember(Value = "Completed")] Completed,
        [EnumMember(Value = "Hidden")] Hidden
    }
	
	public class TaskItemWrapper
	{
		public TaskItem Task { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}

