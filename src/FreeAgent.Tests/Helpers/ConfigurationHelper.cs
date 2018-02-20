
namespace FreeAgent.Tests
{
    public static partial class Helper
    {
        public static Configuration Configuration()
        {
            return new Configuration
            {
                ApplicationKey = "**AppKeyHere**",
                ApplicationSecret = "**AppSecretHere**",
                RefreshToken = "**RefreshTokenHere**",
                UseSandbox = true,
                CurrentToken = "**CurrentTokenHere**"
            };
        }
    }

}
