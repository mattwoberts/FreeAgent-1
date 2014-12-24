using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum AccessRequestType
    {
        [EnumMember(Value = "authorization_code")] authorization_code,
        [EnumMember(Value = "refresh_token")] refresh_token
    }

}

