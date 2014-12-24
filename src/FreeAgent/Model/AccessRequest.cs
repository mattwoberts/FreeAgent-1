using Refit;

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
}

