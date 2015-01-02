using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum BillingPeriod
    {
        [EnumMember(Value = "hour")] Hour,
        [EnumMember(Value = "day")] Day
    }
}

