using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum BillStatus 
    {
        [EnumMember(Value = "Overdue")] Overdue,
        [EnumMember(Value = "Open")] Open
    }
}

