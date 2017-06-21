using System;
using System.Linq;

namespace FreeAgent.Helpers
{
    public static class UriHelpers
    {
        public static int GetId(this IUrl item)
        {
            return GetId(item.Url);
        }

        public static int GetId(this Uri uri)
        {
            if (uri == null || uri.Segments.Length <= 0)
                throw new FreeAgentException("Cannot extract ID from blank Url");

            var idVal = uri.Segments.Last();

            int id = 0;

            if (!int.TryParse(idVal, out id))
                throw new FreeAgentException(string.Format("Cannot extract ID, expected an integer [{0}]", uri.AbsoluteUri));

            return id;
        }
    }
}
