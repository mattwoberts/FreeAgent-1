using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum RebillType 
    {
        [EnumMember(Value = null)] None,
        [EnumMember(Value = "markup")] Markup,
        [EnumMember(Value = "price")] Price,
        [EnumMember(Value = "cost")] Cost
    }
}

