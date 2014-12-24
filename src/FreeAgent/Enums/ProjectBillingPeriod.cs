using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum ProjectBillingPeriod
    {
        [EnumMember(Value = "hour")] Hour,
        [EnumMember(Value = "day")] Day
    }
}