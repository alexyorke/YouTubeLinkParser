using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTubeLinkParser
{
    public class YoutubeUri
    {
        /// <summary>
        /// Parses a YouTube URI, and throws a FormatException if the URL is invalid or does not contain any information.
        /// </summary>
        /// <param name="url">The URL to parse</param>
        /// <param name="shouldIgnoreDomain">Whether the domain should be ignored while parsing. This is useful if YouTube adds more domains after
        /// this has been published or when using services which mimic YouTube's URL pattern for compatibility.</param>
        public YoutubeUri(string url, bool shouldIgnoreDomain = false)
        {
            if (!TryCreate(url, out var uri, shouldIgnoreDomain))
                throw new FormatException("The channel id, user, playlist id, search results, or video id were not found.");

            ChannelId = uri?.ChannelId;
            VideoId = uri?.VideoId;
            UserId = uri?.UserId;
            PlaylistId = uri?.PlaylistId;
            SearchResults = uri?.SearchResults;
        }

        private YoutubeUri()
        {
        }

        public string? ChannelId { get; private set; }
        public string? UserId { get; private set; }
        public string? VideoId { get; private set; }
        public string? PlaylistId { get; private set; }
        public string? SearchResults { get; private set; }

        /// <summary>
        /// Returns the normalized Uri of the YouTube link but only supports a single attribute in this order:
        /// channel id, video id, search result, playlist id, or user id. If none are set this returns null.
        /// </summary>
        public Uri? Uri
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ChannelId)) return new Uri($"https://youtube.com/channel/{HttpUtility.UrlEncode(ChannelId)}");

                if (!string.IsNullOrWhiteSpace(VideoId)) return new Uri($"https://youtube.com/watch?v={VideoId}");

                if (!string.IsNullOrWhiteSpace(PlaylistId))
                    return new Uri($"https://youtube.com/playlist?list={PlaylistId}");

                if (!string.IsNullOrWhiteSpace(SearchResults))
                    return new Uri($"https://youtube.com/results?search_query={HttpUtility.UrlEncode(SearchResults)}");

                return !string.IsNullOrWhiteSpace(UserId) ? new Uri(
                    $"https://youtube.com/user/{HttpUtility.UrlEncode(UserId)}") : null;
            }
        }

        private static HashSet<string> ValidHosts
        {
            get
            {
                var validHosts = new List<string>
                {
                    "gaming.youtube.com",
                    "music.youtube.com",
                    "studio.youtube.com",
                    "tv.youtube.com",
                    "youtu.be",
                    "yt.be",
                    "youtube",
                    "m.youtube",
                    "youtube-nocookie.com",
                    "youtube.googleapis.com",
                    "youtubekids.com"
                };
                var tlds = new List<string>
                {
                    "ae",
                    "at",
                    "au",
                    "az",
                    "ba",
                    "be",
                    "bg",
                    "bh",
                    "bo",
                    "br",
                    "by",
                    "ca",
                    "cat",
                    "ch",
                    "cl",
                    "co",
                    "co.ae",
                    "co.at",
                    "co.cr",
                    "co.hu",
                    "co.id",
                    "co.il",
                    "co.in",
                    "co.jp",
                    "co.ke",
                    "co.kr",
                    "co.ma",
                    "co.nz",
                    "co.th",
                    "co.tz",
                    "co.ug",
                    "co.uk",
                    "co.ve",
                    "co.za",
                    "co.zw",
                    "com",
                    "com.ar",
                    "com.au",
                    "com.az",
                    "com.bd",
                    "com.bh",
                    "com.bo",
                    "com.br",
                    "com.by",
                    "com.co",
                    "com.do",
                    "com.ec",
                    "com.ee",
                    "com.eg",
                    "com.es",
                    "com.gh",
                    "com.gr",
                    "com.gt",
                    "com.hk",
                    "com.hn",
                    "com.hr",
                    "com.jm",
                    "com.jo",
                    "com.kw",
                    "com.lb",
                    "com.lv",
                    "com.ly",
                    "com.mk",
                    "com.mt",
                    "com.mx",
                    "com.my",
                    "com.ng",
                    "com.ni",
                    "com.om",
                    "com.pa",
                    "com.pe",
                    "com.ph",
                    "com.pk",
                    "com.pt",
                    "com.py",
                    "com.qa",
                    "com.ro",
                    "com.sa",
                    "com.sg",
                    "com.sv",
                    "com.tn",
                    "com.tr",
                    "com.tw",
                    "com.ua",
                    "com.uy",
                    "com.ve",
                    "cr",
                    "cz",
                    "de",
                    "dk",
                    "ee",
                    "es",
                    "fi",
                    "fr",
                    "ge",
                    "gr",
                    "gt",
                    "hk",
                    "hr",
                    "hu",
                    "ie",
                    "il",
                    "in",
                    "iq",
                    "is",
                    "it",
                    "jo",
                    "jp",
                    "kr",
                    "kz",
                    "lk",
                    "lt",
                    "lu",
                    "lv",
                    "ly",
                    "ma",
                    "me",
                    "mk",
                    "mx",
                    "my",
                    "net.in",
                    "ng",
                    "ni",
                    "nl",
                    "no",
                    "nz",
                    "pa",
                    "pe",
                    "ph",
                    "pk",
                    "pl",
                    "pr",
                    "pt",
                    "qa",
                    "ro",
                    "rs",
                    "ru",
                    "sa",
                    "se",
                    "sg",
                    "si",
                    "sk",
                    "sn",
                    "sv",
                    "tn",
                    "tv",
                    "tw",
                    "ua",
                    "ug",
                    "uk",
                    "uy",
                    "vn",
                    "voto",
                    "za"
                };

                validHosts.AddRange(validHosts.ToList().Select(host => $"{host}."));
                
                validHosts.AddRange(tlds.Select(tld => $"youtube.{tld}"));
                validHosts.AddRange(tlds.Select(tld => $"youtube.{tld}."));
                validHosts.AddRange(tlds.Where(tld => !tld.Contains(".")).Select(tld => $"{tld}.youtube.com"));
                validHosts.AddRange(tlds.Select(tld => $"m.youtube.{tld}"));
                validHosts.AddRange(tlds.Select(tld => $"www.youtube.{tld}"));

                return new HashSet<string>(validHosts, StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        ///     Try to parse a given YouTube URL. Accepts any unparsed YouTube URL which can be opened using any modern desktop
        ///     web-browser,
        ///     assuming that there are no HTTP-level redirects from a different domain.
        ///     If a link shortener or a redirection domain is used, it has to be resolved and redirected to the final location
        ///     before
        ///     using this parser.
        /// </summary>
        /// <param name="unparsedYouTubeUri">The unparsed YouTube URL.</param>
        /// <param name="youtubeUri">The parsed YouTube URL, otherwise null if it could not be parsed.</param>
        /// <returns>Whether the URL could be parsed.</returns>
        public static bool TryCreate(string unparsedYouTubeUri, out YoutubeUri? youtubeUri, bool shouldIgnoreDomain = false)
        {
            youtubeUri = new YoutubeUri();

            unparsedYouTubeUri = unparsedYouTubeUri.Trim().Trim('\'').Trim('\"');
            unparsedYouTubeUri = new string(unparsedYouTubeUri.Where(c => !char.IsControl(c) || c == ' ').ToArray());

            // Uri.TryCreate requires that the URL has a protocol
            var httpPrefixedUnparsedYouTubeLink = unparsedYouTubeUri;
            if (!unparsedYouTubeUri.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) &&
                !unparsedYouTubeUri.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) &&
                !unparsedYouTubeUri.StartsWith("//"))
                httpPrefixedUnparsedYouTubeLink = $"https://{unparsedYouTubeUri}";

            // if it's not a URL there's nothing we can do
            if (!Uri.TryCreate(httpPrefixedUnparsedYouTubeLink, UriKind.Absolute, out var parsedYouTubeLink))
            {
                youtubeUri = null;
                return false;
            }

            // remove port (if it exists)
            if (!UriIsValidYouTubeDomain(parsedYouTubeLink) && !shouldIgnoreDomain) return false;
            var domain = Services.GetDomainPart(parsedYouTubeLink.ToString());
            var isShortUrl = domain == "youtu.be" || domain == "www.youtu.be" || domain == "www.yt.be" || domain == "yt.be";

            // TODO: check URLs with commas in them to make sure this doesn't throw any exceptions
            // YouTube ignores everything before the comma in a URL, sometimes...
            if (isShortUrl && unparsedYouTubeUri.Contains(","))
            {
                // if both are valid YouTube domains, choose the last one otherwise choose the first
                var splitUris = unparsedYouTubeUri.Split(",");
                
                // I don't know the behavior for more than two comas in a URI yet
                if (splitUris.Length > 2)
                {
                    youtubeUri = null;
                    return false;
                }

                var chosenUri = "";
                Uri.TryCreate(splitUris.First(), UriKind.Absolute, out var firstUri);
                Uri.TryCreate(splitUris.Last(), UriKind.Absolute, out var lastUri);

                if (firstUri != null && UriIsValidYouTubeDomain(firstUri))
                {
                    chosenUri = (lastUri != null && UriIsValidYouTubeDomain(lastUri)) ? splitUris.Last() : splitUris.First();
                }

                if (!Uri.TryCreate(chosenUri, UriKind.Absolute, out var newUrl))
                {
                    youtubeUri = null;
                    return false;
                }

                parsedYouTubeLink = newUrl;
            }

            List<string> pathComponents;

            // TODO: some carefully crafted URLs might cause this to throw an exception when the URL is re-parsed
            // URLs like https://youtube.com/#/...
            if (parsedYouTubeLink.Fragment.StartsWith("#") || parsedYouTubeLink.Fragment.StartsWith("?#"))
            {
                var parsedYouTubeLinkWithoutFragment =
                    new Uri(parsedYouTubeLink.ToString().Replace("/#/", "/").Replace("/?#/", "/"));
                pathComponents = parsedYouTubeLinkWithoutFragment.AbsolutePath
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                parsedYouTubeLink = parsedYouTubeLinkWithoutFragment;
            }
            else
            {
                pathComponents = parsedYouTubeLink.AbsolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }

            var queryString = HttpUtility.ParseQueryString(parsedYouTubeLink.Query);

            var channelId = Parsers.GetChannelId(pathComponents, queryString,
                isShortUrl, parsedYouTubeLink.Fragment);
            var userId = Parsers.GetUserId(pathComponents, queryString, parsedYouTubeLink.Fragment);
            var videoId = Parsers.GetVideoId(pathComponents, queryString,
                isShortUrl, parsedYouTubeLink.Fragment);
            var playlistId = Parsers.GetPlaylistId(queryString, parsedYouTubeLink.Fragment);
            var searchResults = Parsers.GetSearchResults(queryString, parsedYouTubeLink.Fragment);

            if (!string.IsNullOrWhiteSpace(channelId) || !string.IsNullOrWhiteSpace(videoId) ||
                !string.IsNullOrWhiteSpace(userId) || !string.IsNullOrWhiteSpace(playlistId) ||
                !string.IsNullOrWhiteSpace(searchResults))
            {
                youtubeUri.ChannelId = channelId;
                youtubeUri.VideoId = videoId;
                youtubeUri.UserId = userId;
                youtubeUri.PlaylistId = playlistId;
                youtubeUri.SearchResults = searchResults;
                return true;
            }

            youtubeUri = null;
            return false;
        }

        private static bool UriIsValidYouTubeDomain(Uri parsedYouTubeLink)
        {
            try
            {
                parsedYouTubeLink =
                    new Uri(parsedYouTubeLink.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port,
                        UriFormat.UriEscaped));

                var domain = Services.GetDomainPart(parsedYouTubeLink.ToString());

                return ValidHosts.Contains(domain);
            }
            catch (UriFormatException)
            {
                // ignored
            }

            return false;
        }


        public override bool Equals(object? obj)
        {
            return obj != null && ((YoutubeUri) obj).VideoId == VideoId &&
                   ((YoutubeUri) obj).ChannelId == ChannelId && ((YoutubeUri) obj).VideoId == VideoId;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return $"{VideoId ?? "<none>"}-{ChannelId ?? "<none>"}-{UserId ?? "<none>"}".GetHashCode();
        }

        public override string ToString()
        {
            return
                $"[VideoID] = {VideoId ?? "<none>"}, [ChannelID] = {ChannelId ?? "<none>"}, [UserID] = {UserId ?? "<none>"}";
        }
    }
}