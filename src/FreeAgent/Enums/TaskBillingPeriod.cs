using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum TaskBillingPeriod
    {
        [EnumMember(Value = "hour")] Hour,
        [EnumMember(Value = "day")] Day
    }
}

