using System.Linq;

namespace Microsoft.AspNetCore.Http
{
    public static class HeaderDictionaryExtensions
    {
        public static string FirstOrDefault(this IHeaderDictionary headers, string key)
        {
            if (headers.TryGetValue(key, out var values) && !string.IsNullOrWhiteSpace(values))
            {
                return values.First().Split(',').First();
            }

            return null;
        }
    }
}
