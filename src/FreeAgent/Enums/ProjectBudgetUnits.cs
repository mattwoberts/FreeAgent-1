using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum ProjectBudgetUnits 
	{
		[EnumMember(Value = "Hours")] Hours,
		[EnumMember(Value = "Days")] Days,
		[EnumMember(Value = "Monetary")] Monetary
	}
}