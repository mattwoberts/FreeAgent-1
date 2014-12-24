using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum TaskStatus 
    {
        [EnumMember(Value = "Active")] Active,
        [EnumMember(Value = "Completed")] Completed,
        [EnumMember(Value = "Hidden")] Hidden
    }
}

