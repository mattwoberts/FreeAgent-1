using System;

namespace FreeAgent
{
    public class Configuration
    {
        public Configuration()
        {
            AutoRefreshMinutes = 120;
        }

        public string ApplicationKey { get; set; }
        public string ApplicationSecret { get; set; }
        public bool UseSandbox { get; set; }
        public string RefreshToken { get; set; }
        public string CurrentToken { get; set; }
        public DateTime? CurrentTokenExpiry { get; set; }
        public int AutoRefreshMinutes { get; set; }

        public string CurrentHeader
        {
            get { return string.Format("Bearer {0}", this.CurrentToken); }
        }

    }
}
