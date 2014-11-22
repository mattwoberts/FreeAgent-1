using System;

namespace FreeAgent.Model
{
	public class AccessResponse
	{
		public string AccessToken { get; set; }
		public string TokenType { get; set; }
		public long ExpiresIn { get; set; }
		public string RefreshToken { get; set; }
	}
}

