using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YouTubeLinkParser
{
    public static class Services
    {
        public static string GetDomainPart(string url)
        {
            var doubleSlashesIndex = url.IndexOf("://", StringComparison.Ordinal);
            var start = doubleSlashesIndex != -1 ? doubleSlashesIndex + "://".Length : 0;
            var end = url.IndexOf("/", start, StringComparison.Ordinal);
            if (end == -1)
                end = url.Length;

            var trimmed = url.Substring(start, end - start);
            if (trimmed.StartsWith("www."))
                trimmed = trimmed.Substring("www.".Length);
            trimmed = trimmed.Split(":").First();
            return trimmed;
        }

        public static string RemoveDiacritics(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();

            foreach (var ch in normalized)
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    builder.Append(ch);

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}