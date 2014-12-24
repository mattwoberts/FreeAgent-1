using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum SalesTaxRegistrationStatus
    {
        [EnumMember(Value = "Registered")] Registered,
        [EnumMember(Value = "Not Registered")] NotRegistered
    }
}
