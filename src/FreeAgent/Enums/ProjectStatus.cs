using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum ProjectStatus 
	{
		[EnumMember(Value = "Active")] Active,
		[EnumMember(Value = "Completed")] Completed,
		[EnumMember(Value = "Cancelled")] Cancelled,
        [EnumMember(Value = "Hidden")] Hidden
	}
}




