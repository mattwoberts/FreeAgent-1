using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum Frequency
    {
        [EnumMember(Value = "Weekly")] Weekly, 
        [EnumMember(Value = "Two Weekly")] TwoWeekly, 
        [EnumMember(Value = "Four Weekly")] FourWeekly, 
        [EnumMember(Value = "Monthly")] Monthly, 
        [EnumMember(Value = "Two Monthly")] TwoMonthly,
        [EnumMember(Value = "Quarterly")] Quarterly, 
        [EnumMember(Value = "BiAnnually")] BiAnnually, 
        [EnumMember(Value = "Annually")] Annually, 
        [EnumMember(Value = "2-Yearly")] TwoYearly 
    }
}
