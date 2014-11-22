using Refit;
using System;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public class AccessRequest
	{
        [AliasAs("client_id")]
        public string ClientId { get; set; }

        [AliasAs("client_secret")]
        public string ClientSecret { get; set; }

        [AliasAs("grant_type")]
        public AccessRequestType GrantType { get; set; }

        [AliasAs("code")]
        public string Code { get; set; }

        [AliasAs("refresh_token")]
        public string RefreshToken { get; set; }
	}

    public enum AccessRequestType
    {
        [EnumMember(Value = "authorization_code")] authorization_code,
        [EnumMember(Value = "refresh_token")] refresh_token
    }

}

