using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum BudgetUnits 
	{
		[EnumMember(Value = "Hours")] Hours,
		[EnumMember(Value = "Days")] Days,
		[EnumMember(Value = "Monetary")] Monetary
	}
}