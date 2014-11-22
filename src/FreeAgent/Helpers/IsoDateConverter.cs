using Newtonsoft.Json.Converters;

namespace FreeAgent.Helpers
{
    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter()
        {
            this.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}